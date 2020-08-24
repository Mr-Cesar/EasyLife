using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Multa
    {
        private long id;
        private Departamento departamento;
        private string motivo;
        private int costo;
        private Boolean estado;
        private DateTime fechaRegistro;
        private BOLETA boleta;

        public BOLETA _boleta
        {
            get { return boleta; }
            set { boleta = value; }
        }

        public DateTime _fechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public Boolean _estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public int _costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public string _motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }

        public Departamento _departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public long _id
        {
            get { return id; }
            set { id = value; }
        }
    }
}