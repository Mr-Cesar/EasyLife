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
    
    public partial class ESTACIONAMIENTO
    {
        public long ID_EST { get; set; }
        public long ID_EDIFICIO { get; set; }
        public string NUMERO_EST { get; set; }
        public int PRECIO_EST { get; set; }
        public Nullable<long> DEP_EST { get; set; }
    
        public virtual EDIFICIO EDIFICIO { get; set; }
    }
}