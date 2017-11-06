using Iae.Comercial.Creditos.Dominio;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Iae.Comercial.Creditos.Contrato
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/ListarCliente",
            BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Cliente> ListarCliente();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/ObtenerCliente/{NumeroDocumento}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        Cliente ObtenerCliente(string NumeroDocumento);
    }
}
