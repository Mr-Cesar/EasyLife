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
    
    public partial class LOGIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOGIN()
        {
            this.PERSONA1 = new HashSet<PERSONA>();
        }
    
        public long ID_LOGIN { get; set; }
        public long ID_PERSONA { get; set; }
        public string FK_RUT { get; set; }
        public string PASSWORD_LOGIN { get; set; }
    
        public virtual PERSONA PERSONA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERSONA> PERSONA1 { get; set; }
    }
}
