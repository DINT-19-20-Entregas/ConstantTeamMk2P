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
    /// Lógica de interacción para Administrar.xaml
    /// </summary>
    public partial class Administrar : Window
    {
        public Administrar()
        {
            InitializeComponent();
            this.DataContext = new AdministrarVM();
            CategoriasListBox.DataContext = (this.DataContext as AdministrarVM).categorias;
            PlatosListBox.DataContext = (this.DataContext as AdministrarVM).platos;
        }

        private void AñadirCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AdministrarVM).AñadirCategoria();
        }

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            IdCategoriaTextBox.IsEnabled = true;
            NombreCategoriaTextBox.IsEnabled = true;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = CategoriasListBox.SelectedItem as Categoria;
            (this.DataContext as AdministrarVM).EliminarCategoria(categoria);
        }

        private void AñadirPlatoButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AdministrarVM).AñadirPlato();
        }

        private void EditarPlatoButton_Click(object sender, RoutedEventArgs e)
        {
            IdPlatoTextBox.IsEnabled = true;
            NombrePlatoTextBox.IsEnabled = true;
        }

        private void EliminarPlatoButton_Click(object sender, RoutedEventArgs e)
        {
            Plato plato = PlatosListBox.SelectedItem as Plato;
            (this.DataContext as AdministrarVM).EliminarPlato(plato);
        }

        private void GuardarCambiosButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AdministrarVM).GuardarCambios();
        }
    }
}
