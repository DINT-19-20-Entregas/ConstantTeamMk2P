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
    
    public partial class Plato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plato()
        {
            this.platosPorPedido = new HashSet<PlatosPorPedido>();
            this.ingredientes = new HashSet<Ingrediente>();
        }
    
        public int idPlato { get; set; }
        public int idCategoria { get; set; }
        public string nombrePlato { get; set; }
        public Nullable<double> precio { get; set; }
        public string imagenPlato { get; set; }
    
        public virtual Categoria categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlatosPorPedido> platosPorPedido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingrediente> ingredientes { get; set; }
    }
}