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
    
    public partial class GASTOS_COMUNES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GASTOS_COMUNES()
        {
            this.BOLETA_GASTO = new HashSet<BOLETA_GASTO>();
            this.EDIFICIO = new HashSet<EDIFICIO>();
        }
    
        public long ID_GASTOS { get; set; }
        public long ID_EDIFICIO { get; set; }
        public int GASTO_CONSERJE { get; set; }
        public int GASTO_GUARDIA { get; set; }
        public int GASTO_MANTENCION_AREAS { get; set; }
        public int GASTO_CAMARAS { get; set; }
        public int GASTO_ARTICULOS_ASEO { get; set; }
        public int GASTOS_ASEO { get; set; }
        public int GASTO_ASCENSOR { get; set; }
        public int GASTO_AGUA_CALIENTE { get; set; }
        public int GASTO_OTRO { get; set; }
        public int TOTAL_GASTO { get; set; }
        public string FECHA_REGISTRO_GASTO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOLETA_GASTO> BOLETA_GASTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EDIFICIO> EDIFICIO { get; set; }
        public virtual EDIFICIO EDIFICIO1 { get; set; }
    }
}