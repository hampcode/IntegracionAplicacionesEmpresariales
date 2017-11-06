using Iae.Comercial.Creditos.Contrato;
using System.Collections.Generic;
using Iae.Comercial.Creditos.Dominio;
using Iae.Comercial.Creditos.Fachada;

namespace Iae.Comercial.Creditos.Implementacion
{
    public class CreditoService : ICreditoService
    {
        public Credito ActualizarCredito(Credito credito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.ActualizarCredito(credito);
            }
        }

        public bool EliminarCredito(string idCredito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.EliminarCredito(idCredito);
            }
        }

        public IEnumerable<Credito> ListarCredito()
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.ListarCredito();
            }
        }

        public Credito RegistrarCredito(Credito credito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.RegistrarCredito(credito);
            }
        }
    }
}
