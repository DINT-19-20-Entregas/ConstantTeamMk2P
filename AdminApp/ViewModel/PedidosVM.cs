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

        public void EliminarPedido(Pedido pedido)
        {
            BBDDService.DeletePedido(pedido);
            MessageBox.Show("Pedido #" + PedidoSeleccionado.idPedido + " servido", "Pedido servido", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
