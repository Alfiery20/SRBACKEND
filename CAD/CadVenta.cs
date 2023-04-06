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

namespace CAD
{
    public class CadVenta
    {
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
    }
}
