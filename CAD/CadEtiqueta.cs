using CEN.Categoria;
using CEN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.Etiqueta;
using CEN.Helpers;
using CEN.Request;

namespace CAD
{
    public class CadEtiqueta
    {
        public CenControlError ListarEtiquetas(ListarEtiquetaRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenEtiqueta> lista = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerEtiquetas", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Etiqueta", request.Codigo == null ? null : request.Codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_Etiqueta", request.Nombre == null ? null : request.Nombre.Trim());
                cmd.Parameters.AddWithValue("@ppage", request.Pagina);
                cmd.Parameters.AddWithValue("@pcount", request.Cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenEtiqueta()
                            {
                                Id = Int32.Parse(reader["id_Etiqueta"].ToString()),
                                Codigo = reader["codigo_Etiqueta"].ToString(),
                                Nombre = reader["nombre_Etiqueta"].ToString(),
                                Estado = reader["estado_Etiqueta"].ToString()
                            }
                        );
                    }
                }
                response.Descripcion = lista.Count == 0 ? "No se encontraron resultados" : "Operacion Exitosa";
                response.Tipo = "R";
                response.Objeto = new Paginado
                {
                    Pagina = request.Pagina,
                    Tamanio = request.Cantidad,
                    Total_Resultados = ContarEtiquetas(request),
                    Data = lista
                };
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
        public CenControlError AgregarEtiqueta(CenAgregarEtiqueta AgregarEtiqueta)
        {
            string accion = "I";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudEtiqueta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Etiqueta", null));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Etiqueta", AgregarEtiqueta.Nombre == null ? null : AgregarEtiqueta.Nombre.Trim()));
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
        public CenControlError EditarEtiqueta(CenEditarEtiqueta EditarEtiqueta)
        {
            string accion = "U";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudEtiqueta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Etiqueta", EditarEtiqueta.Id == null ? null : EditarEtiqueta.Id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Etiqueta", EditarEtiqueta.Nombre == null ? null : EditarEtiqueta.Nombre.Trim()));
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
        public CenControlError EliminarEtiqueta(CenEliminarEtiqueta EliminarEtiqueta)
        {
            string accion = "D";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudEtiqueta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Etiqueta", EliminarEtiqueta.Id == null ? null : EliminarEtiqueta.Id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Etiqueta", null));
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
        public CenControlError ObtenerEtiqueta(int id)
        {
            CenControlError response = new();
            SqlConnection _sqlConexion = new(Constants.Cadena_conexion);
            SqlCommand cmd;
            CenCategoria categoria = new();

            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerEtiqueta", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_Etiqueta", id == 0 ? null : id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())

                    if (reader.Read())
                    {
                        categoria.Id = Int32.Parse(reader["id_Etiqueta"].ToString());
                        categoria.Codigo = reader["codigo_Etiqueta"].ToString();
                        categoria.Nombre = reader["nombre_Etiqueta"].ToString();
                        categoria.Estado = reader["estado_Etiqueta"].ToString();
                    }

                response.Descripcion = string.IsNullOrEmpty(categoria.Codigo) ? "Categoría no encontrada" : "Operacion Exitosa";
                response.Tipo = "R";
                response.Objeto = categoria;
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
        private int ContarEtiquetas(ListarEtiquetaRequest request)
        {
            int total = 0;
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenCategoria> lista = new List<CenCategoria>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_ContarEtiquetas", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Etiqueta", request.Codigo == null ? null : request.Codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_Etiqueta", request.Nombre == null ? null : request.Nombre.Trim());
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
