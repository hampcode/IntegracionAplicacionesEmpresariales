using Iae.Comercial.Creditos.Contrato;
using System.Collections.Generic;
using Iae.Comercial.Creditos.Dominio;
using Iae.Comercial.Creditos.Fachada;

namespace Iae.Comercial.Creditos.Implementacion
{
    public class ClienteService : IClienteService
    {
        public IEnumerable<Cliente> ListarCliente()
        {
            using (var instancia = new ClienteFachada())
            {
                return instancia.ListarCliente();
            }
        }

        public Cliente ObtenerCliente(string NumeroDocumento)
        {
            using (var instancia = new ClienteFachada())
            {
                return instancia.ObtenerCliente(NumeroDocumento);
            }
        }
    }
}
