using CEN.Imagen;
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
using CEN.Categoria;

namespace CAD
{
    public class CadImagen
    {
        public CenControlError ListarImagen(ListarImagenesRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenImagen> lista = new List<CenImagen>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerImagenes", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_Producto", request.id_producto == null ? null : request.id_producto);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenImagen()
                            {
                                Id = Int32.Parse(reader["id_Imagen"].ToString()),
                                NombreOriginal = reader["nombre_Original"].ToString(),
                                NombrePresenta = Constants.Base_url_cloud + Constants.Dimensions
                                                + reader["nombre_Presentacion"].ToString(),
                            }
                        );
                    }
                }
                response.Codigo = "OK";
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
        public CenControlError AgregarImagen(CenAgregarImagen AgregarImagen)
        {
            string accion = "I";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudImagen", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Imagen", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", AgregarImagen.IdProducto == null ? null : AgregarImagen.IdProducto));
                cmd.Parameters.Add(new SqlParameter("@pnombreOriginal_Imagen", AgregarImagen.NombreOriginal == null ? null : AgregarImagen.NombreOriginal.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pnombrePresentacion_Imagen", AgregarImagen.NombrePresenta == null ? null : AgregarImagen.NombrePresenta.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pdescripcion_Imagen", AgregarImagen.Descripcion == null ? null : AgregarImagen.Descripcion.Trim()));
                cmd.Parameters.Add(new SqlParameter("@paccion", accion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Codigo = "OK";
                        response.Tipo = accion;
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
        public CenControlError EliminarImagen(CenEliminarImagen EliminarImagen)
        {
            string accion = "D";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudImagen", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Imagen", EliminarImagen.Id == null ? null : EliminarImagen.Id));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pnombreOriginal_Imagen", null));
                cmd.Parameters.Add(new SqlParameter("@pnombrePresentacion_Imagen", null));
                cmd.Parameters.Add(new SqlParameter("@pdescripcion_Imagen", null));
                cmd.Parameters.Add(new SqlParameter("@paccion", accion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Codigo = "OK";
                        response.Tipo = accion;
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
        public CenControlError ObtenerImagen(int id)
        {
            CenControlError response = new();
            SqlConnection _sqlConexion = new(Constants.Cadena_conexion);
            SqlCommand cmd;
            CenImagen Imagen = new();

            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerImagen", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_Imagen", id == 0 ? null : id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())

                    if (reader.Read())
                    {
                        Imagen.Id = Int32.Parse(reader["id_Imagen"].ToString());
                        Imagen.NombreOriginal = reader["nombre_Original"].ToString();
                        Imagen.NombrePresenta = Constants.Base_url_cloud + reader["nombre_Presentacion"].ToString();
                        Imagen.Descripcion = reader["descripcion"].ToString();
                    }

                response.Descripcion = string.IsNullOrEmpty(Imagen.NombreOriginal) ? "Categoría no encontrada" : "Operacion Exitosa";
                response.Codigo = "OK";
                response.Tipo = "R";
                response.Objeto = Imagen;
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
        public int ContarImagen(ListarImagenesRequest request)
        {
            int total = 0;
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenCategoria> lista = new List<CenCategoria>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_ContarImagen", _sqlConexion);
                cmd.Parameters.AddWithValue("pid_Producto", request.id_producto == null ? null : request.id_producto);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        total = Int32.Parse(reader["TOTAL_REGISTROS"].ToString());
                    }
                }
                return total;
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
