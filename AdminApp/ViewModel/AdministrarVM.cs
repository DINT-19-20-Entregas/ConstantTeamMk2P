using AdminApp.Model;
using AdminApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApp.ViewModel
{
    public class AdministrarVM : INotifyPropertyChanged
    {
        public ObservableCollection<Categoria> categorias { get; set; }
        public ObservableCollection<Plato> platos { get; set; }
        public Plato platoSeleccionado { get ; set; }
        public Categoria categoriaSeleccionada { get; set; }

        public AdministrarVM()
        {
            categorias = BBDDService.GetCategorias();
            platos = BBDDService.GetPlatos();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AñadirCategoria(Categoria categoria)
        {
            BBDDService.AddCategoria(categoria);
            MessageBox.Show("Se ha añadido la categoría " + categoria.nombreCategoria, "Añadir categoría", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void EliminarCategoria(Categoria categoria)
        {   
            BBDDService.DeleteCategoria(categoria);
            MessageBox.Show("Se ha eliminado la categoría " + categoria.nombreCategoria, "Eliminar categoría", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void AñadirPlato(Plato plato)
        {
            BBDDService.AddPlato(plato);
        }

        public void EliminarPlato(Plato plato)
        {
            BBDDService.DeletePlato(plato);
        }

        public void GuardarCambios()
        {
            MessageBox.Show("Se han guardado los cambios", "Guardar cambios", MessageBoxButton.OK, MessageBoxImage.Information);
            BBDDService.ActualizarBBDD();
        }

        public bool CategoriaVacia(Categoria categoria)
        {
            return categoria.platos.Count == 0;
        }
    }
}
