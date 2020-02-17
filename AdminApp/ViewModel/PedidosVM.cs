using AdminApp.Model;
using AdminApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApp.ViewModel
{
    public class PedidosVM : INotifyPropertyChanged
    {
        public Pedido PedidoSeleccionado { get; set; }
        public ObservableCollection<Pedido> ListaPedidos { get; set; }


        public PedidosVM()
        {
            ListaPedidos = BBDDService.GetPedidosOrdenadosPorFecha();
        }

        public void EliminarPedidos()
        {
            List<Pedido> pedidosServidos = new List<Pedido>(BBDDService.GetPedidosServidos());

            foreach(Pedido p in pedidosServidos)
            {
                BBDDService.DeletePedido(p);
            }

            BBDDService.ActualizarBBDD();

            
            MessageBox.Show("Pedidos servidos eliminados correctamente", "Limpiar pedidos servidos", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void MarcarComoServido(Pedido pedido)
        {
            pedido.servido = true;
            BBDDService.ActualizarBBDD();
            MessageBox.Show("Pedido #" + pedido.idPedido + " marcado como servido", "Pedido servido", MessageBoxButton.OK, MessageBoxImage.Information);
            
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
