using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWebCreditos.Models
{
    public class CreditoViewModel
    {
        public int IdCredito { get; set; }

        public int TipoCredito { get; set; }

        public int IdCliente { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        public Decimal Monto { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DiaPago { get; set; }

        public Decimal Tasa { get; set; }

        public Decimal Comision { get; set; }
    }
}