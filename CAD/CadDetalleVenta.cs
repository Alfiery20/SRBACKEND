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
using CEN.Response;
using CEN.DetalleVenta;

namespace CAD
{
    public class CadDetalleVenta
    {
        public CenControlError ListarDetalleVenta(ListarDetalleVentaRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<DetalleVentaResponse> lista = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerDetalleVenta", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_Venta", request.IdVenta == null ? null : request.IdVenta);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new DetalleVentaResponse()
                            {
                                Id = Int32.Parse(reader["id_DetalleVenta"].ToString()),
                                IdProducto = Int32.Parse(reader["id_Producto"].ToString()),
                                NombreProducto = reader["nombre_Producto"].ToString(),
                                Cantidad = Int32.Parse(reader["cantidad"].ToString()),
                                PrecioVenta = Double.Parse(reader["precio_Venta"].ToString())
                            }
                        );
                    }
                }
                bool tipoRespuesta = lista.Count == 0;
                response.Descripcion = tipoRespuesta ? "No se encontraron resultados" : "Operacion Exitosa";
                response.Codigo = tipoRespuesta ? "EX" : "OK";
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
        public CenControlError AgregarDetalleVenta(CenAgregarDetalleVenta AgregarDetalleVenta)
        {
            string accion = "I";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudDetalleVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_DetalleVenta", null));
                cmd.Parameters.Add(new SqlParameter("@pcantidad", AgregarDetalleVenta.Cantidad == null ? null : AgregarDetalleVenta.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", AgregarDetalleVenta.IdProducto == null ? null : AgregarDetalleVenta.IdProducto));
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", AgregarDetalleVenta.IdVenta == null ? null : AgregarDetalleVenta.IdVenta));
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
        public CenControlError EditarDetalleVenta(CenEditarDetalleVenta EditarDetalleVenta)
        {
            string accion = "U";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudDetalleVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_DetalleVenta", EditarDetalleVenta.Id == null ? null : EditarDetalleVenta.Id));
                cmd.Parameters.Add(new SqlParameter("@pcantidad", EditarDetalleVenta.Cantidad == null ? null : EditarDetalleVenta.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", null));
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
        public CenControlError EliminarDetalleVenta(CenEliminarDetalleVenta EliminarDetalleVenta)
        {
            string accion = "D";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudDetalleVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_DetalleVenta", EliminarDetalleVenta.Id));
                cmd.Parameters.Add(new SqlParameter("@pcantidad", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pprecioVenta", null));
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
    }
}
