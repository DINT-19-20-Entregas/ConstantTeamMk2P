using ClientApp.Model;
using ClientApp.ViewModel;
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
//using System.Newtonsoft.Json;
using System.Net;
using System.Diagnostics;

namespace ClientApp.View
{
    /// <summary>
    /// Lógica de interacción para Cuenta.xaml
    /// </summary>
    public partial class Cuenta : Window
    {
        public Cuenta(Pedido pedido)
        {
            this.DataContext = new CuentaVM(pedido);
            (this.DataContext as CuentaVM).ObtenerPrecioCOnIva();
            InitializeComponent();
            
        }

        private void RetrocederCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void RetrocederCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ConfirmarCuentaCommand_Executed(object sender, ExecutedRoutedEventArgs e) 
        {
            (this.DataContext as CuentaVM).GuardarPedido();
        }

        private void AbrirAyudaCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start("ApiRestaurantHelp.chm");
        }

        private void AbrirAyudaCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ConfirmarCuentaCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((this.DataContext as CuentaVM).Pedidoa.platosPorPedido.Count != null)
            {
                if ((this.DataContext as CuentaVM).Pedidoa.platosPorPedido.Count > 0)
                    e.CanExecute = true;
                else
                    e.CanExecute = false;
            }
            else
                e.CanExecute = false;
        }
    }
}
