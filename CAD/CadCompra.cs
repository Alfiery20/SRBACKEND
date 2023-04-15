using CEN.Compra;
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
using CEN.Compra;
using CEN.Venta;

namespace CAD
{
    public class CadCompra
    {
        public CenControlError ListarCompra(ListarCompraRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CompraResponse> lista = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerCompra", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Compra", request.CodigoCompra == null ? null : request.CodigoCompra.Trim());
                cmd.Parameters.AddWithValue("@pfecha_minima", request.FechaMinima == null ? null : request.FechaMinima);
                cmd.Parameters.AddWithValue("@pfecha_maxima", request.FechaMaxima == null ? null : request.FechaMaxima);
                cmd.Parameters.AddWithValue("@pestado_compra", request.EstadoCompra == null ? null : request.EstadoCompra);
                cmd.Parameters.AddWithValue("@ppage", request.Pagina);
                cmd.Parameters.AddWithValue("@pcount", request.Cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CompraResponse()
                            {
                                IdCompra = Int32.Parse(reader["id_compra"].ToString()),
                                CodigoCompra = reader["codigo_Compra"] == DBNull.Value ? null : reader["codigo_Compra"].ToString(),
                                Cantidad = Int32.Parse(reader["cantidad"].ToString()),
                                CostoCompra = double.Parse(reader["costo_Compra"].ToString()),
                                FechaCompra = DateTime.Parse(reader["fecha_Compra"].ToString()),
                                IdProducto = Int32.Parse(reader["id_producto"].ToString()),
                                NombreProducto = reader["nombre_Producto"].ToString(),
                                IdUsuarioInserta = Int32.Parse(reader["id_usuarioInserta"].ToString()),
                                NombreUsuarioInserta = reader["nombre_usuario_inserta"].ToString(),
                                FechaEdita = reader["fecha_Edita"] == DBNull.Value ? null : DateTime.Parse(reader["fecha_Edita"].ToString()),
                                IdUsuarioEdita = reader["id_usuarioEdita"] == DBNull.Value ? null : Int32.Parse(reader["id_usuarioEdita"].ToString()),
                                NombreUsuarioEdita = reader["nombre_usuario_edita"] == DBNull.Value ? null : reader["nombre_usuario_edita"].ToString(),
                                FechaEliminar = reader["fecha_Elimina"] == DBNull.Value ? null : DateTime.Parse(reader["fecha_Elimina"].ToString()),
                                IdUsuarioElimina = reader["id_usuarioElimina"] == DBNull.Value ? null : Int32.Parse(reader["id_usuarioElimina"].ToString()),
                                NombreUsuarioElimina = reader["nombre_usuario_elimina"] == DBNull.Value ? null : reader["nombre_usuario_elimina"].ToString(),
                                EstadoCompra = reader["estado_Compra"].ToString()
                            }
                        );
                    }
                }
                bool tipoRespuesta = lista.Count == 0;
                response.Descripcion = tipoRespuesta ? "No se encontraron resultados" : "Operacion Exitosa";
                response.Codigo = tipoRespuesta ? "EX" : "OK";
                response.Tipo = "R";
                response.Objeto = new Paginado
                {
                    Pagina = request.Pagina,
                    Tamanio = request.Cantidad,
                    Total_Resultados = 0,//ContarCompra(request),
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
        public CenControlError AgregarCompra(CenAgregarCompra AgregarCompra)
        {
            string accion = "I";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudCompra", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Compra", null));
                cmd.Parameters.Add(new SqlParameter("@pcosto_Compra", AgregarCompra.CostoCompra == null ? null : AgregarCompra.CostoCompra));
                cmd.Parameters.Add(new SqlParameter("@pcantidad", AgregarCompra.Cantidad == null ? null : AgregarCompra.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", AgregarCompra.IdProducto == null ? null : AgregarCompra.IdProducto));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioInserta", AgregarCompra.idUsuarioInserta == null ? null : AgregarCompra.idUsuarioInserta));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioEdita", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioElimina", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Compra", null));
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
        public CenControlError CambiarAEnCamino(CenEditarCompra EditarCompra)
        {
            string accion = "U";
            string estado = "E";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudCompra", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Compra", EditarCompra.IdCompra == null ? null : EditarCompra.IdCompra));
                cmd.Parameters.Add(new SqlParameter("@pcosto_Compra", null));
                cmd.Parameters.Add(new SqlParameter("@pcantidad", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioInserta", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioEdita", EditarCompra.idUsuarioEdita == null ? null : EditarCompra.idUsuarioEdita));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioElimina", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Compra", estado));
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
        public CenControlError CambiarAFinalizar(CenEditarCompra EditarCompra)
        {
            string accion = "U";
            string estado = "F";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudCompra", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Compra", EditarCompra.IdCompra == null ? null : EditarCompra.IdCompra));
                cmd.Parameters.Add(new SqlParameter("@pcosto_Compra", null));
                cmd.Parameters.Add(new SqlParameter("@pcantidad", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioInserta", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioEdita", EditarCompra.idUsuarioEdita == null ? null : EditarCompra.idUsuarioEdita));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioElimina", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Compra", estado));
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
        public CenControlError CambiarARechazada(CenEliminarCompra EliminarCompra)
        {
            string accion = "D";
            string estado = "R";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudCompra", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Compra", EliminarCompra.IdCompra == null ? null : EliminarCompra.IdCompra));
                cmd.Parameters.Add(new SqlParameter("@pcosto_Compra", null));
                cmd.Parameters.Add(new SqlParameter("@pcantidad", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioInserta", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioEdita", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioElimina", EliminarCompra.idUsuarioElimina == null ? null : EliminarCompra.idUsuarioElimina));
                cmd.Parameters.Add(new SqlParameter("@pestado_Compra", estado));
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
        public CenControlError CambiarGeneral(CenEditarGeneralCompra GeneralCompra)
        {
            string accion = "U";
            string estado = "D";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudCompra", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Compra", GeneralCompra.IdCompra == null ? null : GeneralCompra.IdCompra));
                cmd.Parameters.Add(new SqlParameter("@pcosto_Compra", GeneralCompra.CostoCompra == null ? null : GeneralCompra.CostoCompra));
                cmd.Parameters.Add(new SqlParameter("@pcantidad", GeneralCompra.Cantidad == null ? null : GeneralCompra.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioInserta", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioEdita", GeneralCompra.idUsuarioEdita == null ? null : GeneralCompra.idUsuarioEdita));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioElimina", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Compra", estado));
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
        private int ContarCompra(ListarCompraRequest request)
        {
            int total = 0;
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenCompra> lista = new List<CenCompra>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_contarCompra", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Compra", request.CodigoCompra == null ? null : request.CodigoCompra.Trim());
                cmd.Parameters.AddWithValue("@pfecha_minima", request.FechaMinima == null ? null : request.FechaMinima);
                cmd.Parameters.AddWithValue("@pfecha_maxima", request.FechaMaxima == null ? null : request.FechaMaxima);
                cmd.Parameters.AddWithValue("@pestado_compra", request.EstadoCompra == null ? null : request.EstadoCompra);
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
