//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlatosPorPedido
    {
        public int idPedido { get; set; }
        public int idPlato { get; set; }
        public int cantidad { get; set; }
    
        public virtual Pedido pedido { get; set; }
        public virtual Plato plato { get; set; }
    }
}
