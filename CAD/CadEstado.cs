using CEN.Categoria;
using CEN.Helpers;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.Estado;

namespace CAD
{
    public class CadEstado
    {
        public CenControlError ListarEstado(ListarEstadoRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenEstado> lista = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerEstados", _sqlConexion);
                cmd.Parameters.AddWithValue("@pnombre_Estado", request.Nombre == null ? null : request.Nombre.Trim());
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenEstado()
                            {
                                Id = Int32.Parse(reader["id_Estado"].ToString()),
                                Codigo = reader["codigo_Estado"].ToString(),
                                Nombre = reader["nombre_Estado"].ToString()
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
