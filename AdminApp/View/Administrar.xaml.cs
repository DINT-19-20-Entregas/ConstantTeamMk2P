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
        }

        private void AñadirCategoriaButton_Click(object sender, RoutedEventArgs e)
        {

            DialogoNuevaCategoria dialogoNuevaCategoria = new DialogoNuevaCategoria();
            dialogoNuevaCategoria.Owner = this;
            dialogoNuevaCategoria.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialogoNuevaCategoria.ShowDialog();            
        }

        private void EditarCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            if((this.DataContext as AdministrarVM).categoriaSeleccionada != null)
            {
                NombreCategoriaTextBox.IsEnabled = true;
                SeleccionarImagenButton.IsEnabled = true;
            }
            
        }

        private void EliminarCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = (this.DataContext as AdministrarVM).categoriaSeleccionada;
            if(categoria != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar la categoría " + categoria.nombreCategoria + "?", "Eliminar categoría", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if ((this.DataContext as AdministrarVM).CategoriaVacia(categoria))
                        (this.DataContext as AdministrarVM).EliminarCategoria(categoria);
                    else
                        MessageBox.Show("La categoría no esta vacía", "Eliminar categoría", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            
        }

        private void AñadirPlatoButton_Click(object sender, RoutedEventArgs e)
        {

            DialogoNuevoPlato dialogoNuevoPlato = new DialogoNuevoPlato();
            dialogoNuevoPlato.Owner = this;
            dialogoNuevoPlato.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialogoNuevoPlato.ShowDialog();
        }

        private void EditarPlatoButton_Click(object sender, RoutedEventArgs e)
        {
            if((this.DataContext as AdministrarVM).platoSeleccionado != null)
            {
                NombrePlatoTextBox.IsEnabled = true;
                ListaCategoriasComboBox.IsEnabled = true;
                PrecioTextBox.IsEnabled = true;
                SeleccionarImagenPlatoButton.IsEnabled = true;
            }
            
        }

        private void EliminarPlatoButton_Click(object sender, RoutedEventArgs e)
        {
            Plato plato = (this.DataContext as AdministrarVM).platoSeleccionado;
            if (plato != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar el plato " + plato.nombrePlato+ "?", "Eliminar plato", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    (this.DataContext as AdministrarVM).EliminarPlato(plato);
                }
            }
            
        }

        

        private void EditarIngredienteButton_Click(object sender, RoutedEventArgs e)
        {
            NombreIngredienteTextBox.IsEnabled = true;
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

        private void PlatosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NombrePlatoTextBox.IsEnabled = false;
            PrecioTextBox.IsEnabled = false;
            ListaCategoriasComboBox.IsEnabled = false;
            SeleccionarImagenPlatoButton.IsEnabled = false;

        }

        private void SeleccionarImagenButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AdministrarVM).categoriaSeleccionada.imagenCategoria = SeleccionarImagen();
            CategoriasListBox.SelectedItem = (this.DataContext as AdministrarVM).categoriaSeleccionada;
        }

        public byte[] SeleccionarImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes png(*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                return ImageConverter.ImageToBinary(openFileDialog.FileName);
            }
            return null;
        }

        private void SeleccionarImagenPlatoButton_Click(object sender, RoutedEventArgs e)
        {
            Plato p = (this.DataContext as AdministrarVM).platoSeleccionado;
            p.imagenPlato = SeleccionarImagen();
        }

        private void AñadirIngredienteButton_Click(object sender, RoutedEventArgs e)
        {
            Ingrediente i = new Ingrediente();
            i.nombreIngrediente = "Nuevo ingrediente";
            (this.DataContext as AdministrarVM).AñadirIngrediente(i);
        }

        private void EliminarIngredienteButton_Click(object sender, RoutedEventArgs e)
        {
            Ingrediente ingrediente = (this.DataContext as AdministrarVM).ingredienteSeleccionado;
            if (ingrediente != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar el ingrediente " + ingrediente.nombreIngrediente + "?", "Eliminar ingrediente", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    (this.DataContext as AdministrarVM).EliminarIngrediente(ingrediente);
                }
            }
        }
    }
}
