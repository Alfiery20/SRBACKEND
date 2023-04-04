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
using CEN.Rol;

namespace CAD
{
    public class CadRol
    {
        public CenControlError ListarRolDeUsuario(ListarRolDeUsuarioRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenRol> lista = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerRolDeUsuario", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_Usuario", request.IdUsuario == null ? null : request.IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenRol()
                            {
                                Id = Int32.Parse(reader["id_Rol"].ToString()),
                                Codigo = reader["codigo_Rol"].ToString(),
                                Nombre = reader["nombre_Rol"].ToString(),
                                Estado = reader["estado_Rol"].ToString()
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
