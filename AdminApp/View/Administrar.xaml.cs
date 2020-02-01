using AdminApp.Model;
using AdminApp.Service;
using AdminApp.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            Categoria nuevaCategoria = new Categoria();

            DialogoNuevaCategoria dialogoNuevaCategoria = new DialogoNuevaCategoria(ref nuevaCategoria);
            dialogoNuevaCategoria.Owner = this;
            dialogoNuevaCategoria.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialogoNuevaCategoria.ShowDialog();            
        }

        private void EditarCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            if(CategoriasListBox.SelectedItem != null)
            {
                NombreCategoriaTextBox.IsEnabled = true;
                SeleccionarImagenButton.IsEnabled = true;
            }
            
        }

        private void EliminarCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = CategoriasListBox.SelectedItem as Categoria;
            MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar la categoría " + categoria.nombreCategoria + "?", "Eliminar categoría", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                if((this.DataContext as AdministrarVM).CategoriaVacia(categoria))
                    (this.DataContext as AdministrarVM).EliminarCategoria(categoria);
                else
                    MessageBox.Show("La categoría no esta vacía", "Eliminar categoría", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void AñadirPlatoButton_Click(object sender, RoutedEventArgs e)
        {
            Plato nuevoPlato = new Plato();
            (this.DataContext as AdministrarVM).AñadirPlato(nuevoPlato);
        }

        private void EditarPlatoButton_Click(object sender, RoutedEventArgs e)
        {
            if(PlatosListBox.SelectedItem != null)
            {
                NombrePlatoTextBox.IsEnabled = true;
            }
            
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

        private void CategoriasListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NombreCategoriaTextBox.IsEnabled = false;
            SeleccionarImagenButton.IsEnabled = false;
        }

        private void SeleccionarImagenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes png(*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                Categoria categoria = CategoriasListBox.SelectedItem as Categoria;                
                categoria.imagenCategoria = ImageConverter.ImageToBinary(openFileDialog.FileName);
            }
        }
    }
}
