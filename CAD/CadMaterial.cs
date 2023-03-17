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
    public class CadMaterial
    {
        public CenControlError ListarMateriales(ListarMaterialRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenMaterial> lista = new List<CenMaterial>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerMateriales", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Material", request.Codigo == null ? null : request.Codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_Material", request.Nombre == null ? null : request.Nombre.Trim());
                cmd.Parameters.AddWithValue("@ppage", request.Pagina);
                cmd.Parameters.AddWithValue("@pcount", request.Cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenMaterial()
                            {
                                Id = Int32.Parse(reader["id_Material"].ToString()),
                                Codigo = reader["codigo_Material"].ToString(),
                                Nombre = reader["nombre_Material"].ToString(),
                                Descripcion = reader["descripcion_Material"].ToString(),
                                Estado = reader["estado_Material"].ToString()
                            }
                        );
                    }
                }
                response.Descripcion = lista.Count == 0 ? "No se encontraron resultados" : "Operacion Exitosa";
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

        public CenControlError IUDMaterial(IUDMaterialRequest materialRequest, string acccion)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudMaterial", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Material", materialRequest.Id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Material", materialRequest.Nombre == null ? null : materialRequest.Nombre.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pdescripcion_Material", materialRequest.Descripcion == null ? null : materialRequest.Descripcion.Trim()));
                cmd.Parameters.Add(new SqlParameter("@paccion", acccion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Tipo = acccion;
                        response.Codigo = reader["CODIGO"].ToString();
                        response.Descripcion = reader["MENSAJE"].ToString();
                    }
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlConexion.Close();
            }
        }

        public CenControlError ObtenerMaterial(int id)
        {
            CenControlError response = new();
            SqlConnection _sqlConexion = new(Constants.Cadena_conexion);
            SqlCommand cmd;
            CenMaterial material = new();

            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerMaterial", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_Material", id == 0 ? null : id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())

                    if (reader.Read())
                    {
                        material.Id = Int32.Parse(reader["id_Material"].ToString());
                        material.Codigo = reader["codigo_Material"].ToString();
                        material.Nombre = reader["nombre_Material"].ToString();
                        material.Estado = reader["estado_Material"].ToString();
                        material.Descripcion = reader["descripcion_Material"].ToString();
                    }

                response.Descripcion = string.IsNullOrEmpty(material.Codigo) ? "Categoría no encontrada" : "Operacion Exitosa";
                response.Tipo = "R";
                response.Objeto = material;
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