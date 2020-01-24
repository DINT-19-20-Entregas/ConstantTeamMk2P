using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Model;

namespace ClientApp.Service
{
    class BBDDService
    {
        private static readonly RestauranteConstanTeamEntities _contexto;

        public static ObservableCollection<categorias> GetCategorias()
        {
            return _contexto.categorias.Local;
        }

        public static ObservableCollection<platos> GetPlatosFromCategory(categorias categoria)
        {
            var consulta = from p in _contexto.platos
                           where p.idCategoria == categoria.idCategoria
                           orderby p.nombrePlato
                           select p;

            return new ObservableCollection<platos>(consulta.ToList());
        }


    }
}
