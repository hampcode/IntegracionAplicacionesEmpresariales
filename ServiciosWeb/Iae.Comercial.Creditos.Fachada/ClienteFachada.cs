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
    public class ClienteFachada : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            IClienteRepositorio instancia = new ClienteRepositorio();
            return instancia.ListarCliente();
        }

        public Cliente ObtenerCliente(string NumeroDocumento)
        {
            IClienteRepositorio instancia = new ClienteRepositorio();
            return instancia.ObtenerCliente(NumeroDocumento);
        }
    }
}
