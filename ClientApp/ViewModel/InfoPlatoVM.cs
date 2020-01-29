using ClientApp.Model;
using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
    class InfoPlatoVM
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

        public void AñadirPlatoAPedido()
        {
            PlatosPorPedido platosPorPedido = new PlatosPorPedido();
            platosPorPedido.idPedido = pedido.idPedido;
            platosPorPedido.idPlato = plato.idPlato;

            pedido.platosPorPedido.Add(platosPorPedido);
        }
    }
}
