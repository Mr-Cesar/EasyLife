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
    
    public partial class HORARIO_CENTRO
    {
        public long ID_HORARIO_CENTRO { get; set; }
        public long ID_CENTRO { get; set; }
        public string DIA_HORARIO { get; set; }
        public string HORA_INICIO_D { get; set; }
        public string HORA_TERMINO_D { get; set; }
        public string HORARIO_COMPLETO { get; set; }
        public Nullable<bool> ESTADO_HORARIO { get; set; }
        public string FECHA_REGISTRO_HORARIO { get; set; }
    
        public virtual CENTRO CENTRO { get; set; }
    }
}
