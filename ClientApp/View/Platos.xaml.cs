using ClientApp.Model;
using ClientApp.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ClientApp.View
{
    /// <summary>
    /// Lógica de interacción para Platos.xaml
    /// </summary>
    public partial class Platos : Window
    {
        PlatosVM VM;

        public Platos(Categoria categoria, Pedido pedido)
        {
            InitializeComponent();
            VM = new PlatosVM(pedido);
            ObservableCollection<PlatosPorPedido> ppp = new ObservableCollection<PlatosPorPedido>(VM.GetPedido().platosPorPedido);
            listaPedido.DataContext = ppp;
            //llamar al metodo que devuelve la lista de tiles
            List<Tile> tiles = VM.InicializarPlatos(categoria);
            IntroducirPlatos(tiles);
        }

        private void CargarInfoPlatoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //int.Parse(((Tile)sender).Tag.ToString())
            VM.CargarInfoPlato(int.Parse(((Tile)e.OriginalSource).Tag.ToString()));
        }

        private void CargarInfoPlatoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RetrocederCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((Platos)sender).Close();
        }

        private void RetrocederCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CargarCuentaCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            VM.CargarCuenta();
        }

        private void CargarCuentaCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void IntroducirPlatos(List<Tile> tiles)
        {
            foreach (Tile item in tiles)
            {
                ContenedorPlatos.Children.Add(item);
            }
        }
    }
}
