using Iae.Comercial.Creditos.ContratoRepositorio;
using System;
using System.Collections.Generic;
using Iae.Comercial.Creditos.Dominio;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Iae.Comercial.Creditos.SqlRepositorio
{
    public class CreditoRepositorio : ICreditoRepositorio
    {
        public Credito ActualizarCredito(Credito credito)
        {
            using (IDbConnection conexion = new SqlConnection(
                ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("IdCredito", credito.IdCredito);
                parametros.Add("TipoCredito", credito.TipoCredito);
                parametros.Add("IdCliente", credito.IdCliente);
                parametros.Add("Fecha", credito.Fecha);
                parametros.Add("Monto", credito.Monto);
                parametros.Add("DiaPago", credito.DiaPago);
                parametros.Add("Tasa", credito.Tasa);
                parametros.Add("Comision", credito.Comision);


                var result = conexion.Execute("sp_credito_actualizar"
                        , param: parametros
                        , commandType: CommandType.StoredProcedure);

                return result > 0 ? credito : new Credito();
            }
        }

        public bool EliminarCredito(string idCredito)
        {
            using (IDbConnection conexion = new SqlConnection(
                ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("IdCredito", idCredito);

                var result = conexion.Execute("sp_credito_eliminar"
                        , param: parametros
                        , commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public IEnumerable<Credito> ListarCredito()
        {
            using (IDbConnection conexion = new SqlConnection(
                ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var coleccion = conexion.Query<Credito>("sp_credito_listar"
                        , commandType: CommandType.StoredProcedure);
                return coleccion;
            }
        }

        public Credito ObtenerCredito(string idCredito)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("IdCredito", idCredito);
                var credito = conexion.QueryFirst<Credito>("dbo.sp_credito_obtener", param: parametros, commandType: CommandType.StoredProcedure);
                return credito;
            }
        }

        public Credito RegistrarCredito(Credito credito)
        {
            using (IDbConnection conexion = new SqlConnection(
                ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("TipoCredito", credito.TipoCredito);
                parametros.Add("IdCliente", credito.IdCliente);
                parametros.Add("Fecha", credito.Fecha);
                parametros.Add("Monto", credito.Monto);
                parametros.Add("DiaPago", credito.DiaPago);
                parametros.Add("Tasa", credito.Tasa);
                parametros.Add("Comision", credito.Comision);
                parametros.Add("IdCredito", credito.IdCredito, 
                    DbType.Int32, ParameterDirection.Output);

                conexion.ExecuteScalar("sp_credito_registrar"
                        , param: parametros
                        , commandType: CommandType.StoredProcedure);

                var pIdCredito = parametros.Get<Int32>("IdCredito");

                credito.IdCredito = pIdCredito;
                return credito;
            }
        }
    }
}
