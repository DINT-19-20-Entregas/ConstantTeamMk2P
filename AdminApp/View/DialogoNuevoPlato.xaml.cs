using AdminApp.Model;
using AdminApp.Service;
using AdminApp.ViewModel;
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

namespace AdminApp.View
{
    /// <summary>
    /// Lógica de interacción para DialogoNuevoPlato.xaml
    /// </summary>
    public partial class DialogoNuevoPlato : Window
    {
        Plato nuevoPlato;
        public DialogoNuevoPlato()
        {
            InitializeComponent();
            nuevoPlato = new Plato();
            ObservableCollection<Categoria> categorias = BBDDService.GetCategorias();
            ListaCategoriasComboBox.DataContext = categorias;
        }

        private void SeleccionarImagenButton_Click(object sender, RoutedEventArgs e)
        {
            nuevoPlato.imagenPlato = (Owner as Administrar).SeleccionarImagen();
            ImagenPlato.DataContext = nuevoPlato;
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            bool platoExiste = false;

            foreach (Plato p in (Owner.DataContext as AdministrarVM).platos)
            {
                if (p.nombrePlato== NombrePlatoTextBox.Text)
                    platoExiste = true;
            }

            if (platoExiste)
                MessageBox.Show("El plato ya existe", "Error al crear plato", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                nuevoPlato.nombrePlato = NombrePlatoTextBox.Text;
                nuevoPlato.precio = double.Parse(PrecioTextBox.Text);
                nuevoPlato.idCategoria = (int)ListaCategoriasComboBox.SelectedValue;
                (Owner.DataContext as AdministrarVM).AñadirPlato(nuevoPlato);
                Close();

            }
        }
    }
}
