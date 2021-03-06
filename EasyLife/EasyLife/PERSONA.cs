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
    
    public partial class PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONA()
        {
            this.BOLETA = new HashSet<BOLETA>();
            this.CONDOMINIO = new HashSet<CONDOMINIO>();
            this.CONSERJE = new HashSet<CONSERJE>();
            this.DEPARTAMENTO = new HashSet<DEPARTAMENTO>();
            this.LOGIN = new HashSet<LOGIN>();
            this.MENSAJE = new HashSet<MENSAJE>();
        }
    
        public long ID_PERSONA { get; set; }
        public Nullable<long> ID_LOGIN { get; set; }
        public long ID_ROL { get; set; }
        public string NOMBRE_PERSONA { get; set; }
        public string APELLIDO_PERSONA { get; set; }
        public string FK_RUT { get; set; }
        public string TELEFONO_PERSONA { get; set; }
        public string CORREO_PERSONA { get; set; }
        public bool ESTADO_PERSONA { get; set; }
        public Nullable<bool> LUZ { get; set; }
        public string SEXO { get; set; }
        public string FECHA_REGISTRO_PERSONA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOLETA> BOLETA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONDOMINIO> CONDOMINIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSERJE> CONSERJE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOGIN> LOGIN { get; set; }
        public virtual LOGIN LOGIN1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAJE> MENSAJE { get; set; }
        public virtual ROL ROL { get; set; }
    }
}
