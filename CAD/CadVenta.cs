using CEN.Categoria;
using CEN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.Helpers;
using CEN.Venta;
using CEN.Request;
using CEN.Response;

namespace CAD
{
    public class CadVenta
    {
        public CenControlError ListarVentas(ListarVentaRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<VentaResponse> lista = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerVentas", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_venta", request.CodigoVenta == null ? null : request.CodigoVenta.Trim());
                cmd.Parameters.AddWithValue("@pfecha_minima", request.FechaMinima == null ? null : request.FechaMinima);
                cmd.Parameters.AddWithValue("@pfecha_maxima", request.FechaMaxima == null ? null : request.FechaMaxima);
                cmd.Parameters.AddWithValue("@pestado_venta", request.EstadoVenta == null ? null : request.EstadoVenta.Trim());
                cmd.Parameters.AddWithValue("@ppage", request.Pagina);
                cmd.Parameters.AddWithValue("@pcount", request.Cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                             new VentaResponse()
                             {
                                 IdVenta = Int32.Parse(reader["id_Venta"].ToString()),
                                 CodigoVenta = reader["codigo_Venta"] == DBNull.Value ? null : reader["codigo_Venta"].ToString(),
                                 FechaSolicitud = DateTime.Parse(reader["fecha_Solicitud"].ToString()),
                                 IdUsuarioAprueba = reader["id_UsuarioAprueba"] == DBNull.Value ? null : Int32.Parse(reader["id_UsuarioAprueba"].ToString()),
                                 NombreAprueba = reader["nombreAprueba"] == DBNull.Value ? null : reader["nombreAprueba"].ToString(),
                                 IdUsuarioEdita = reader["id_UsuarioEdita"] == DBNull.Value ? null : Int32.Parse(reader["id_UsuarioEdita"].ToString()),
                                 NombreEdita = reader["nombreEdita"] == DBNull.Value ? null : reader["nombreEdita"].ToString(),
                                 FechaEdita = reader["fecha_Edita"] == DBNull.Value ? null : DateTime.Parse(reader["fecha_Edita"].ToString()),
                                 FechaEntrega = reader["fecha_Entrega"] == DBNull.Value ? null : DateTime.Parse(reader["fecha_Entrega"].ToString()),
                                 DireccionEntrega = reader["direccion_Entrega"].ToString(),
                                 EstadoVenta = reader["estado_Venta"].ToString(),
                                 IdCondado = Int32.Parse(reader["id_Condado"].ToString())
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
                    Total_Resultados = ContarVenta(request),
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
        public CenControlError CrearCarritoCompras(CenAgregarVenta AgregarVenta)
        {
            string accion = "I";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioAprueba_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioEdita_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pfechaEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pdireccionEntrega_Venta", AgregarVenta.DireccionEntrega == null ? null : AgregarVenta.DireccionEntrega.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pestado_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Condado", AgregarVenta.IdCondado == null ? null : AgregarVenta.IdCondado));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioComprador", AgregarVenta.IdUsuarioComprador == null ? null : AgregarVenta.IdUsuarioComprador));
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
        public CenControlError CambiarAPendiente(CenEditarVentaPendiente PendienteVenta)
        {
            string accion = "U";
            string estado = "P";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", PendienteVenta.Id));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioAprueba_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioEdita_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pfechaEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pdireccionEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Venta", estado));
                cmd.Parameters.Add(new SqlParameter("@pid_Condado", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioComprador", null));
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
        public CenControlError CambiarAAprobada(CenEditarVentaAprobada AprobarVenta)
        {
            string accion = "U";
            string estado = "A";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", AprobarVenta.Id));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioAprueba_Venta", AprobarVenta.IdUsuarioAprueba == null ? null : AprobarVenta.IdUsuarioAprueba));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioEdita_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pfechaEntrega_Venta", AprobarVenta.FechaEntrega == null ? null : AprobarVenta.FechaEntrega));
                cmd.Parameters.Add(new SqlParameter("@pdireccionEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Venta", estado));
                cmd.Parameters.Add(new SqlParameter("@pid_Condado", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioComprador", null));
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
        public CenControlError CambiarAEnCamino(CenEditaVentaEnCamino EnCaminoVenta)
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
                cmd = new SqlCommand("sp_iudVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", EnCaminoVenta.Id));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioAprueba_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioEdita_Venta", EnCaminoVenta.IdUsuarioEdita == null ? null : EnCaminoVenta.IdUsuarioEdita));
                cmd.Parameters.Add(new SqlParameter("@pfechaEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pdireccionEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Venta", estado));
                cmd.Parameters.Add(new SqlParameter("@pid_Condado", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioComprador", null));
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
        public CenControlError CambiarAFinaliza(CenEditaVentaFinaliza FinalizaVenta)
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
                cmd = new SqlCommand("sp_iudVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", FinalizaVenta.Id));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioAprueba_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioEdita_Venta", FinalizaVenta.IdUsuarioEdita == null ? null : FinalizaVenta.IdUsuarioEdita));
                cmd.Parameters.Add(new SqlParameter("@pfechaEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pdireccionEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Venta", estado));
                cmd.Parameters.Add(new SqlParameter("@pid_Condado", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioComprador", null));
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
        public CenControlError CambiarDestino(CenEditarVentaDestino DestinoVenta)
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
                cmd = new SqlCommand("sp_iudVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", DestinoVenta.Id));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioAprueba_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioEdita_Venta", DestinoVenta.IdUsuarioEdita == null ? null : DestinoVenta.IdUsuarioEdita));
                cmd.Parameters.Add(new SqlParameter("@pfechaEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pdireccionEntrega_Venta", DestinoVenta.DireccionEntrega == null ? null : DestinoVenta.DireccionEntrega.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pestado_Venta", estado));
                cmd.Parameters.Add(new SqlParameter("@pid_Condado", DestinoVenta.IdCondado == null ? null : DestinoVenta.IdCondado));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioComprador", null));
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
        public CenControlError CambiarARechazar(CenEditarVentaRechazar RechazarVenta)
        {
            string accion = "D";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudVenta", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Venta", RechazarVenta.Id));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioAprueba_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pidUsuarioEdita_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pfechaEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pdireccionEntrega_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pestado_Venta", null));
                cmd.Parameters.Add(new SqlParameter("@pid_Condado", null));
                cmd.Parameters.Add(new SqlParameter("@pid_UsuarioComprador", null));
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
        private int ContarVenta(ListarVentaRequest request)
        {
            int total = 0;
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_ContarVentas", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_venta", request.CodigoVenta == null ? null : request.CodigoVenta.Trim());
                cmd.Parameters.AddWithValue("@pfecha_minima", request.FechaMinima == null ? null : request.FechaMinima);
                cmd.Parameters.AddWithValue("@pfecha_maxima", request.FechaMaxima == null ? null : request.FechaMaxima);
                cmd.Parameters.AddWithValue("@pestado_venta", request.EstadoVenta == null ? null : request.EstadoVenta.Trim());
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
