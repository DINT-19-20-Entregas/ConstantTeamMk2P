using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
            contexto.platosPorPedido.Load();
        }

        public static void CargarBD()
        {            
        }

        // CONSULTAR TODOS LOS REGISTROS DE LAS TABLAS
        public static ObservableCollection<Categoria> GetCategorias()
        {
            return contexto.categorias.Local;
        }

        public static ObservableCollection<Plato> GetPlatos()
        {
            return contexto.platos.Local;
        }

        public static ObservableCollection<Pedido> GetPedidos()
        {
            return contexto.pedidos.Local;
        }

        public static ObservableCollection<Ingrediente> GetIngredientes()
        {
            return contexto.ingredientes.Local;
        }

        // Añadir y eliminar
        public static int AddPlato(Plato item)
        {
            contexto.platos.Add(item);
            return contexto.SaveChanges();
        }

        public static int AddPedido(Pedido item)
        {
            contexto.pedidos.Add(item);
            return contexto.SaveChanges();
        }

        public static int AddIngrediente(Ingrediente item)
        {    

            contexto.ingredientes.Add(item);
            return contexto.SaveChanges();
        }

        public static int AddCategoria(Categoria item)
        {

            contexto.categorias.Add(item);
            return contexto.SaveChanges();
        }

        public static int DeletePlato(Plato item)
        {
            contexto.platos.Remove(item);
            return contexto.SaveChanges();
        }

        public static int DeleteCategoria(Categoria item)
        {
            contexto.categorias.Remove(item);
            return contexto.SaveChanges();
        }

        public static int DeletePedido(Pedido item)
        {
            contexto.pedidos.Remove(item);
            return contexto.SaveChanges();
        }
        public static int DeleteIngrediente(Ingrediente item)
        {
            contexto.ingredientes.Remove(item);
            return contexto.SaveChanges();
        }



        
        public static ObservableCollection<Plato> GetPlatosFromCategoria(Categoria categoria)
        {
            return new ObservableCollection<Plato>(categoria.platos);
        }

        public static ObservableCollection<Ingrediente> GetIngredientesFromPlato(Plato plato)
        {
            return new ObservableCollection<Ingrediente>(plato.ingredientes);
        }

        public static ObservableCollection<Plato> GetPlatosFromPedido(Pedido pedido)
        {
            var consulta = from p in contexto.platosPorPedido
                           where p.idPedido == pedido.idPedido
                           select p.plato;

            return new ObservableCollection<Plato>(consulta);
        }



        public static int ActualizarBBDD()
        {
            return contexto.SaveChanges();
        }

    }
}
