using Iae.Comercial.Creditos.ContratoRepositorio;
using Iae.Comercial.Creditos.Dominio;
using Iae.Comercial.Creditos.SqlRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iae.Comercial.Creditos.Fachada
{
    public class CreditoFachada: IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Credito> ListarCredito()
        {
            ICreditoRepositorio instancia = new CreditoRepositorio();
            return instancia.ListarCredito();
        }

        public Credito RegistrarCredito(Credito credito)
        {
            ICreditoRepositorio instancia = new CreditoRepositorio();
            return instancia.RegistrarCredito(credito);
        }

        public Credito ActualizarCredito(Credito credito)
        {
            ICreditoRepositorio instancia = new CreditoRepositorio();
            return instancia.ActualizarCredito(credito);
        }
        public bool EliminarCredito(string idCredito)
        {
            ICreditoRepositorio instancia = new CreditoRepositorio();
            return instancia.EliminarCredito(idCredito);
        }
    }
}
