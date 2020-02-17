using ClientApp.Model;
using ClientApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para InfoPlato.xaml
    /// </summary>
    public partial class InfoPlato : Window
    {
        private int cantidadPlatos = 0;

        public InfoPlato(Plato plato, Pedido pedido)
        {
            InitializeComponent();
            this.DataContext = new InfoPlatoVM(plato,pedido);
            ListaIngredientes.DataContext = (this.DataContext as InfoPlatoVM).listaIngredientes;
            //PrecioPlatoTextBlock.DataContext = (this.DataContext as InfoPlatoVM).plato;
            NombrePlatoTextBlock.DataContext = (this.DataContext as InfoPlatoVM).plato;
            CantidadTextBlock.Text = cantidadPlatos.ToString();
        }

        private void AñadirPlato_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (this.DataContext as InfoPlatoVM).AñadirPlatoAPedido(cantidadPlatos);
            Close();
        }

        private void AñadirPlato_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
           e.CanExecute = cantidadPlatos > 0;
        }

        private void RetrocederCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void RetrocederCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
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

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            cantidadPlatos++;
            CantidadTextBlock.Text = cantidadPlatos.ToString();
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(CantidadTextBlock.Text) > 0)
            {
                cantidadPlatos--;
                CantidadTextBlock.Text = cantidadPlatos.ToString(); 
            }
                
        }
    }
}
