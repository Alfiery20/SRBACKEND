using CEN.Estado;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.Helpers;

namespace CAD
{
    public class CadCondado
    {
        public CenControlError ListarCondado(ListarCondadoRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenEstado> lista = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerCondados", _sqlConexion);
                cmd.Parameters.AddWithValue("@pnombre_condado", request.NombreCondado == null ? null : request.NombreCondado.Trim());
                cmd.Parameters.AddWithValue("@pid_estado", request.IdEstado == null ? null : request.IdEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenEstado()
                            {
                                Id = Int32.Parse(reader["id_Condado"].ToString()),
                                Codigo = reader["codigo_Condado"].ToString(),
                                Nombre = reader["nombre_Condado"].ToString()
                            }
                        );
                    }
                }
                response.Descripcion = lista.Count == 0 ? "No se encontraron resultados" : "Operacion Exitosa";
                response.Codigo = "OK";
                response.Tipo = "R";
                response.Objeto = lista;
                return response;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                _sqlConexion.Close();
            }
        }
    }
}
