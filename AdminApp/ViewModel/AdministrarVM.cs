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
        public ObservableCollection<Ingrediente> ingredientes { get; set; }
        public Plato platoSeleccionado { get ; set; }
        public Categoria categoriaSeleccionada { get; set; }
        public Ingrediente ingredienteSeleccionado { get; set; }

        public AdministrarVM()
        {
            categorias = BBDDService.GetCategorias();
            platos = BBDDService.GetPlatos();
            ingredientes = BBDDService.GetIngredientes();
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
            MessageBox.Show("Se ha añadido el plato " + plato.nombrePlato, "Añadir plato", MessageBoxButton.OK, MessageBoxImage.Information);
            BBDDService.AddPlato(plato);
        }

        public void AñadirIngrediente(Ingrediente ingrediente)
        {
            MessageBox.Show("Se ha añadido un nuevo ingrediente, modifique sus propiedades", "Añadir ingrediente", MessageBoxButton.OK, MessageBoxImage.Information);
            BBDDService.AddIngrediente(ingrediente);
        }

        public void EliminarIngrediente(Ingrediente ingrediente)
        {
            BBDDService.DeleteIngrediente(ingrediente);
            MessageBox.Show("Se ha eliminado el ingrediente " + ingrediente.nombreIngrediente, "Eliminar ingrediente", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void EliminarPlato(Plato plato)
        {
            BBDDService.DeletePlato(plato);
            MessageBox.Show("Se ha eliminado el plato " + plato.nombrePlato, "Eliminar plato", MessageBoxButton.OK, MessageBoxImage.Information);
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
