using Iae.Comercial.Creditos.ContratoRepositorio;
using System;
using System.Collections.Generic;
using Iae.Comercial.Creditos.Dominio;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Iae.Comercial.Creditos.SqlRepositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public IEnumerable<Cliente> ListarCliente()
        {
            using (IDbConnection conexion = new SqlConnection(
                ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var cliente = conexion.Query<Cliente>("sp_cliente_listar",
                    commandType: CommandType.StoredProcedure);
                return cliente;
            }
        }

        public Cliente ObtenerCliente(string NumeroDocumento)
        {
            using (IDbConnection conexion = new SqlConnection(
                ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("pNumeroDocumento", NumeroDocumento);

                var cliente = conexion.QuerySingle<Cliente>("sp_cliente_obtener", 
                    param: parametros, commandType: CommandType.StoredProcedure);
                return cliente;
            }
        }
    }
}
