﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApp.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RestauranteEntities : DbContext
    {
        public RestauranteEntities()
            : base("name=RestauranteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> categorias { get; set; }
        public virtual DbSet<Ingrediente> ingredientes { get; set; }
        public virtual DbSet<Pedido> pedidos { get; set; }
        public virtual DbSet<Plato> platos { get; set; }
        public virtual DbSet<platosPorPedido> platosPorPedido { get; set; }
    }
}