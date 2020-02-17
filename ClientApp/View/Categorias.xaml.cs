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
using System.Diagnostics;
using System.IO;

namespace ClientApp.View
{
    /// <summary>
    /// Lógica de interacción para Categorias.xaml
    /// </summary>
    public partial class Categorias : Window
    {        

        public Categorias()
        {
            InitializeComponent();
            this.DataContext = new CategoriasVM();
            (this.DataContext as CategoriasVM).Inicializacion();
            ObservableCollection<PlatosPorPedido> platos = (this.DataContext as CategoriasVM).Pedidoa.platosPorPedido;

            //PlatosPorPedido ppp = new PlatosPorPedido();
            //ppp.pedido = VM.GetPedido();
            //ppp.cantidad = 3;
            //Plato p = new Plato();
            //p.nombrePlato = "Pollo";
            //ppp.plato = p;
            //platos.Add(ppp);
            //VM.GetPedido().platosPorPedido.Add(ppp);

            listaPedido.DataContext = platos;
            List<Tile> tiles = (this.DataContext as CategoriasVM).InicializarCategorias();
            IntroducirCategorias(tiles);
            precioTotalButtonTextBlock.DataContext = (this.DataContext as CategoriasVM).Pedidoa;
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
            (this.DataContext as CategoriasVM).CargarPlatos(int.Parse(((Tile)e.OriginalSource).Tag.ToString()));
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
            (this.DataContext as CategoriasVM).CargarCuenta();
        }

        private void CargarCuentaCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        
        private void AbrirAyudaCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {            
            Process.Start("..\\..\\Assets\\ApiRestaurantHelp.chm");
        }

        private void AbrirAyudaCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
