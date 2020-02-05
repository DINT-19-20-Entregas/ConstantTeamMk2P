using System;
using ClientApp.ViewModel;
using ClientApp.Model;
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
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;

namespace ClientApp.View
{
    /// <summary>
    /// Lógica de interacción para Categorias.xaml
    /// </summary>
    public partial class Categorias : Window
    {
        private CategoriasVM VM;

        public Categorias()
        {
            InitializeComponent();
            VM = new CategoriasVM();
            VM.Inicializacion();
            ObservableCollection<PlatosPorPedido> platos = new ObservableCollection<PlatosPorPedido>(VM.GetPedido().platosPorPedido);

            PlatosPorPedido ppp = new PlatosPorPedido();
            ppp.pedido = VM.GetPedido();
            ppp.cantidad = 3;
            Plato p = new Plato();
            p.nombrePlato = "Pollo";
            ppp.plato = p;
            platos.Add(ppp);
            VM.GetPedido().platosPorPedido.Add(ppp);

            listaPedido.DataContext = platos;
            List<Tile> tiles = VM.InicializarCategorias();
            IntroducirCategorias(tiles);
        }

        private void IntroducirCategorias(List<Tile> tiles)
        {
            foreach (Tile item in tiles)
            {
                ContenedorCategorias.Children.Add(item);
            }
        }

        private void CargarPlatosCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //int.Parse(((Tile)sender).Tag.ToString())
            VM.CargarPlatos(int.Parse(((Tile)e.OriginalSource).Tag.ToString()));
        }

        private void CargarPlatosCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RetrocederCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((Categorias)sender).Close();
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
    }
}
