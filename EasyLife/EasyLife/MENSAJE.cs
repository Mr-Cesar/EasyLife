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
    
    public partial class MENSAJE
    {
        public long ID_MENSAJE { get; set; }
        public long ID_TIPO_MENSAJE { get; set; }
        public Nullable<long> ID_PERSONA { get; set; }
        public string DESCRIPCION_MENSAJE { get; set; }
        public string EMISOR_MENSAJE { get; set; }
        public string DESTINATARIO_MENSAJE { get; set; }
        public Nullable<bool> ESTADO_MENSAJE { get; set; }
        public string FECHA_REGISTRO_M { get; set; }
    
        public virtual PERSONA PERSONA { get; set; }
        public virtual TIPO_MENSAJE TIPO_MENSAJE { get; set; }
    }
}