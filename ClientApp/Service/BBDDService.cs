using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Service
{
    public static class BBDDService
    {
        private static readonly RestauranteEntities contexto;

        static BBDDService()
        {
            contexto = new RestauranteEntities();
            
            contexto.pedidos.Load();
            contexto.platos.Load();
            contexto.categorias.Load();
            contexto.ingredientes.Load();
        }

        public static ObservableCollection<Categoria> GetCategorias()
        {
            return contexto.categorias.local();
        }

        public static ObservableCollection<Plato> GetPlatos()
        {
            return contexto.platos.Local;
        }

        public static ObservableCollection<Pedido> GetPedidos()
        {
            return contexto.platos.Local;
        }

        public static ObservableCollection<Ingrediente> GetIngredientes()
        {
            return contexto.ingredientes.Local;
        }

        public static int AddPlato(Plato item)
        {
            contexto.platos.Add(item);
            return contexto.platos.SaveChanges();
        }

        public static int AddPedido(Pedido item)
        {
            contexto.pedidos.Add(item);
            return contexto.pedidos.SaveChanges();
        }

        public static int AddIngrediente(Ingrediente item)
        {    

            contexto.ingredientes.Add(item);
            return contexto.ingredientes.SaveChanges();
        }

        public static int AddCategoria(Categoria item)
        {

            contexto.categorias.Add(item);
            return contexto.categorias.SaveChanges();
        }

        public static int DeletePlato(Plato item)
        {
            contexto.platos.Remove(item);
            return contexto.platos.SaveChanges();
        }

        public static int DeleteCategoria(Categoria item)
        {
            contexto.categorias.Remove(item);
            return contexto.categorias.SaveChanges();
        }

        public static int DeletePedido(Pedido item)
        {
            contexto.pedidos.Remove(item);
            return contexto.pedidos.SaveChanges();
        }
        public static int DeleteIngrediente(Ingrediente item)
        {
            contexto.ingredientes.Remove(item);
            return contexto.ingredientes.SaveChanges();
        }

        public static ObservableCollection<Plato> GetPlatosFromCategoria(Categoria categoria)
        {
            var consulta = from p in contexto.platos
                           where p.idCategoria == categoria.idCategoria
                           orderby p.nombrePlato
                           select p;

            return new ObservableCollection<Plato>(consulta.ToList());
        }

        public static ObservableCollection<Plato> GetIngredientesFromPlato(Plato plato)
        {
            var consulta = from i in contexto.ingredientes
                           where i.idPlato == plato.idPlato
                           orderby i.nombreIngrediente
                           select i;

            return new ObservableCollection<Plato>(consulta.ToList());
        }

        public static ObservableCollection<Plato> GetPlatosFromPedido(Pedido pedido)
        {
            var consulta = from p in contexto.pedidos
                           where p.idPedido == pedido.idPedido
                           select p;

            return new ObservableCollection<Plato>(consulta.ToList());
        }



        public static int ActualizarBBDD()
        {
            return 0;
        }

    }
}
