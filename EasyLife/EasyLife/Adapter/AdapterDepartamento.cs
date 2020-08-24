using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterDepartamento
    {
        private long ID_DEPARTAMENTO;
        private string NUMERO_DEP;
        private string FK_RUT;
        private string NOMBRE_PERSONA;
        private string CODIGO_LUZ_D;
        private int MULTA;
        private long ID_EDIFICIO;
        private long ID_CONDOMINIO;
        private string NOMBRE_EDIFICIO;
        private string NOMBRE_CONDOMINIO;
        private int COSTO_MULTA;
        private long ID_MULTA;
        private string MOTIVO;
        private Boolean ESTADO_MULTA;

        public Boolean _ESTADO_MULTA
        {
            get { return ESTADO_MULTA; }
            set { ESTADO_MULTA = value; }
        }

        public string _MOTIVO
        {
            get { return MOTIVO; }
            set { MOTIVO = value; }
        }

        public long _ID_MULTA
        {
            get { return ID_MULTA; }
            set { ID_MULTA = value; }
        }

        public int _COSTO_MULTA
        {
            get { return COSTO_MULTA; }
            set { COSTO_MULTA = value; }
        }

        public string _NOMBRE_CONDOMINIO
        {
            get { return NOMBRE_CONDOMINIO; }
            set { NOMBRE_CONDOMINIO = value; }
        }

        public string _NOMBRE_EDIFICIO
        {
            get { return NOMBRE_EDIFICIO; }
            set { NOMBRE_EDIFICIO = value; }
        }

        public long _ID_CONDOMINIO
        {
            get { return ID_CONDOMINIO; }
            set { ID_CONDOMINIO = value; }
        }

        public long _ID_EDIFICIO
        {
            get { return ID_EDIFICIO; }
            set { ID_EDIFICIO = value; }
        }

        public int _MULTA
        {
            get { return MULTA; }
            set { MULTA = value; }
        }

        public string _CODIGO_LUZ_D
        {
            get { return CODIGO_LUZ_D; }
            set { CODIGO_LUZ_D = value; }
        }

        public string _NOMBRE_PERSONA
        {
            get { return NOMBRE_PERSONA; }
            set { NOMBRE_PERSONA = value; }
        }

        public string _FK_RUT
        {
            get { return FK_RUT; }
            set { FK_RUT = value; }
        }

        public string _NUMERO_DEP
        {
            get { return NUMERO_DEP; }
            set { NUMERO_DEP = value; }
        }

        public long _ID_DEPARTAMENTO
        {
            get { return ID_DEPARTAMENTO; }
            set { ID_DEPARTAMENTO = value; }
        }
    }
}