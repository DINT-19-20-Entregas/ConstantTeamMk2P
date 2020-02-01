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
    /// Lógica de interacción para DialogoNuevaCategoria.xaml
    /// </summary>
    public partial class DialogoNuevaCategoria : Window
    {
        Categoria nuevaCategoria;
        public DialogoNuevaCategoria(ref Categoria nuevaCategoria)
        {
            InitializeComponent();
            this.nuevaCategoria = nuevaCategoria;
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            bool categoriaExiste = false;

            foreach(Categoria c in (Owner.DataContext as AdministrarVM).categorias)
            {
                if (c.nombreCategoria == NombreCategoriaTextBox.Text)
                    categoriaExiste = true;                    
            }

            if (categoriaExiste)
                MessageBox.Show("La categoría ya existe", "Error al crear categoria", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                nuevaCategoria.nombreCategoria = NombreCategoriaTextBox.Text;
                (Owner.DataContext as AdministrarVM).AñadirCategoria(nuevaCategoria);                
                Close();
            }

            
        }
    }
}
