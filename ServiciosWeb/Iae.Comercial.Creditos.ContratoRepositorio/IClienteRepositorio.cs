using Iae.Comercial.Creditos.Dominio;
using System.Collections.Generic;

namespace Iae.Comercial.Creditos.ContratoRepositorio
{
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> ListarCliente();

        Cliente ObtenerCliente(string NumeroDocumento);
    }
}
