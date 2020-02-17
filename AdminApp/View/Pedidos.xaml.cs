using AdminApp.Model;
using AdminApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdminApp.View
{
    /// <summary>
    /// Lógica de interacción para Pedidos.xaml
    /// </summary>
    public partial class Pedidos : Window
    {
        public Pedidos()
        {
            InitializeComponent();
            this.DataContext = new PedidosVM();
        }

        private void PedidoServidoButton_Click(object sender, RoutedEventArgs e)
        {
            if((this.DataContext as PedidosVM).PedidoSeleccionado != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Estas seguro de marcar el pedido (#" + (this.DataContext as PedidosVM).PedidoSeleccionado.idPedido + ") como servido ?", "Marcar pedido como servido", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Pedido pedido = (this.DataContext as PedidosVM).PedidoSeleccionado;
                    (this.DataContext as PedidosVM).MarcarComoServido(pedido);
                }
            }
            
        }

        private void LimpiarPedidosButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as PedidosVM).EliminarPedidos();
        }
    }
}
