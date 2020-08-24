using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterBoletaGasto
    {
        private long ID_BOLETA;
        private long ID_GASTOS;
        private string FK_RUT;
        private string NOMBRE_EDIFICIO;
        private long ID_EDIFICIO;
        private long ID_DEPARTAMENTO;
        private string NUMERO_DEP;
        private long TOTAL_GASTO;
        private long COSTO_BOLETA;
        private long MULTA;
        private string MES;
        private string AÑO;

        public string _AÑO
        {
            get { return AÑO; }
            set { AÑO = value; }
        }

        public string _MES
        {
            get { return MES; }
            set { MES = value; }
        }

        public long _MULTA
        {
            get { return MULTA; }
            set { MULTA = value; }
        }

        public long _COSTO_BOLETA
        {
            get { return COSTO_BOLETA; }
            set { COSTO_BOLETA = value; }
        }

        public long _TOTAL_GASTO
        {
            get { return TOTAL_GASTO; }
            set { TOTAL_GASTO = value; }
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

        public long _ID_EDIFICIO
        {
            get { return ID_EDIFICIO; }
            set { ID_EDIFICIO = value; }
        }

        public string _NOMBRE_EDIFICIO
        {
            get { return NOMBRE_EDIFICIO; }
            set { NOMBRE_EDIFICIO = value; }
        }

        public string _FK_RUT
        {
            get { return FK_RUT; }
            set { FK_RUT = value; }
        }

        public long _ID_GASTOS
        {
            get { return ID_GASTOS; }
            set { ID_GASTOS = value; }
        }

        public long _ID_BOLETA
        {
            get { return ID_BOLETA; }
            set { ID_BOLETA = value; }
        }
    }
}