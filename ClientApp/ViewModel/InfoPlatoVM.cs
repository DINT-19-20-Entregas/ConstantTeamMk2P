using ClientApp.Model;
using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
    class InfoPlatoVM : INotifyPropertyChanged
    {
        public Plato plato { get; set; }
        public Pedido pedido { get; set; }

        public ObservableCollection<Ingrediente> listaIngredientes{ get; set; }


        public InfoPlatoVM(Plato plato, Pedido pedido)
        {
            this.plato = plato;
            this.pedido = pedido;
            listaIngredientes = new ObservableCollection<Ingrediente>(plato.ingredientes);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AñadirPlatoAPedido(int cantidad)
        {
            PlatosPorPedido platosPorPedido;
            if (pedido.platosPorPedido.Where(p => p.idPlato == plato.idPlato).Count() > 0)
            {
                platosPorPedido = pedido.platosPorPedido.Where(p => p.idPlato == plato.idPlato).First();
                int cantidadActual = platosPorPedido.cantidad;
                pedido.platosPorPedido.Remove(platosPorPedido);

                platosPorPedido = new PlatosPorPedido();
                platosPorPedido.idPedido = pedido.idPedido;
                platosPorPedido.idPlato = plato.idPlato;
                platosPorPedido.cantidad = cantidad + cantidadActual;
                platosPorPedido.plato = plato;
                platosPorPedido.pedido = pedido;
                pedido.precioTotal += plato.precio * cantidad;
                pedido.platosPorPedido.Add(platosPorPedido);
            }
            else
            {
                platosPorPedido = new PlatosPorPedido();
                platosPorPedido.idPedido = pedido.idPedido;
                platosPorPedido.idPlato = plato.idPlato;
                platosPorPedido.cantidad = cantidad;
                platosPorPedido.plato = plato;
                platosPorPedido.pedido = pedido;
                pedido.precioTotal += plato.precio * cantidad;
                pedido.platosPorPedido.Add(platosPorPedido);
            }
                
        }
    }
}
