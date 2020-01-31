using AdminApp.Model;
using AdminApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.ViewModel
{
    public class AdministrarVM
    {
        public ObservableCollection<Categoria> categorias;
        public ObservableCollection<Plato> platos;

        public AdministrarVM()
        {
            categorias = BBDDService.GetCategorias();
            platos = BBDDService.GetPlatos();
        }

        public void AñadirCategoria()
        {
            Categoria categoria = new Categoria();
            categoria.idCategoria = 0;
            categoria.nombreCategoria = "Nueva categoria";

            BBDDService.AddCategoria(categoria);
        }

        public void EliminarCategoria(Categoria categoria)
        {
            BBDDService.DeleteCategoria(categoria);
        }

        public void AñadirPlato()
        {
            Plato plato = new Plato();
            plato.idCategoria = 0;
            plato.nombrePlato = "Nueva plato";

            BBDDService.AddPlato(plato);
        }

        public void EliminarPlato(Plato plato)
        {
            BBDDService.DeletePlato(plato);
        }
    }
}
