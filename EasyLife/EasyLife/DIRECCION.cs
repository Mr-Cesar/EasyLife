//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyLife
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIRECCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIRECCION()
        {
            this.CONDOMINIO = new HashSet<CONDOMINIO>();
        }
    
        public long ID_DIRECCION { get; set; }
        public Nullable<long> ID_CONDOMINIO { get; set; }
        public long ID_COMUNA { get; set; }
        public string CALLE { get; set; }
        public int NUMERO { get; set; }
    
        public virtual COMUNA COMUNA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONDOMINIO> CONDOMINIO { get; set; }
        public virtual CONDOMINIO CONDOMINIO1 { get; set; }
    }
}
