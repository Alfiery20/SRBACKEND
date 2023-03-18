using CEN.TipoDocumento;
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

namespace CAD
{
    public class CadTipoDocumento
    {
        public CenControlError ListarTipoDocumento(ListarTipoDocumentoRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenTipoDocumento> lista = new List<CenTipoDocumento>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerTipoDocumentos", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_TipoDocumento", request.Codigo == null ? null : request.Codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_TipoDocumento", request.Nombre == null ? null : request.Nombre.Trim());
                cmd.Parameters.AddWithValue("@ppage", request.Page);
                cmd.Parameters.AddWithValue("@pcount", request.Cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenTipoDocumento()
                            {
                                Id = Int32.Parse(reader["id_TipoDocumento"].ToString()),
                                Codigo = reader["codigo_TipoDocumento"].ToString(),
                                Nombre = reader["nombre_TipoDocumento"].ToString(),
                                LongitudMax = Int32.Parse(reader["longitud_Max"].ToString()),
                                EstadoDocumento = reader["estado_TipoDocumento"].ToString()
                            }
                        );
                    }
                }
                response.Descripcion = lista.Count == 0 ? "No se encontraron resultados" : "Operacion Exitosa";
                response.Tipo = "R";
                response.Objeto = new Paginado
                {
                    Pagina = request.Page,
                    Tamanio = request.Cantidad,
                    Total_Resultados = ContarTipoDocumento(request),
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
        public CenControlError AgregarTipoDocumento(CenAgregarTipoDocumento AgregarTipoDocumento)
        {
            string accion = "I";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudTipoDocumento", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_TipoDocumento", null));
                cmd.Parameters.Add(new SqlParameter("@pnombre_TipoDocumento", AgregarTipoDocumento.Nombre == null ? null : AgregarTipoDocumento.Nombre.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pnombre_TipoDocumento", AgregarTipoDocumento.LongitudMax == null ? null : AgregarTipoDocumento.LongitudMax));
                cmd.Parameters.Add(new SqlParameter("@paccion", accion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
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
        public CenControlError EditarTipoDocumento(CenEditarTipoDocumento EditarTipoDocumento)
        {
            string accion = "U";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudTipoDocumento", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_TipoDocumento", EditarTipoDocumento.Id == null ? null : EditarTipoDocumento.Id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_TipoDocumento", EditarTipoDocumento.Nombre == null ? null : EditarTipoDocumento.Nombre.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pnombre_TipoDocumento", EditarTipoDocumento.LongitudMax == null ? null : EditarTipoDocumento.LongitudMax));
                cmd.Parameters.Add(new SqlParameter("@paccion", accion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
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
        public CenControlError EliminarTipoDocumento(CenEliminarTipoDocumento EliminarTipoDocumento)
        {
            string accion = "D";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudTipoDocumento", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_TipoDocumento", EliminarTipoDocumento.Id == null ? null : EliminarTipoDocumento.Id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_TipoDocumento", null));
                cmd.Parameters.Add(new SqlParameter("@pnombre_TipoDocumento", null));
                cmd.Parameters.Add(new SqlParameter("@paccion", accion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
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
        public CenControlError ObtenerTipoDocumento(int id)
        {
            CenControlError response = new();
            SqlConnection _sqlConexion = new(Constants.Cadena_conexion);
            SqlCommand cmd;
            CenTipoDocumento TipoDocumento = new();

            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerTipoDocumento", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_TipoDocumento", id == 0 ? null : id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())

                    if (reader.Read())
                    {
                        TipoDocumento.Id = Int32.Parse(reader["id_TipoDocumento"].ToString());
                        TipoDocumento.Codigo = reader["codigo_TipoDocumento"].ToString();
                        TipoDocumento.Nombre = reader["nombre_TipoDocumento"].ToString();
                        TipoDocumento.EstadoDocumento = reader["estado_TipoDocumento"].ToString();
                    }

                response.Descripcion = string.IsNullOrEmpty(TipoDocumento.Codigo) ? "Categoría no encontrada" : "Operacion Exitosa";
                response.Tipo = "R";
                response.Objeto = TipoDocumento;
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
        private int ContarTipoDocumento(ListarTipoDocumentoRequest request)
        {
            int total = 0;
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenTipoDocumento> lista = new List<CenTipoDocumento>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_ContarTipoDocumentos", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_TipoDocumento", request.Codigo == null ? null : request.Codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_TipoDocumento", request.Nombre == null ? null : request.Nombre.Trim());
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
