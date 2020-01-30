using AdminApp.Service;
using AdminApp.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BBDDService.CargarBD();
        }

        private void AbrirVentanaCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Button botonOrigen = (Button)e.OriginalSource;
            if (botonOrigen.Name == "PedidosButton")
            {

            }
            else
            {
                new Administrar().Show();
            }
        }

        private void AbrirVentanaCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
