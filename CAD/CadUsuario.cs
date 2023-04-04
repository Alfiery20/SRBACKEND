using CEN.Request;
using CEN.Response;
using CEN;
using Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.Helpers;
using Services.Encrypt;
using CEN.Usuario;

namespace CAD
{
    public class CadUsuario
    {
        public CenControlError AgregarUsuario(CenAgregarUsuario iUDUsuario)
        {
            String Accion = "I";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudUsuario", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid", null));
                cmd.Parameters.Add(new SqlParameter("@pnumero_Documento", iUDUsuario.NumerDocumento == null ? null : iUDUsuario.NumerDocumento.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pnombre", iUDUsuario.NombreCompleto == null ? null : iUDUsuario.NombreCompleto.Trim()));
                cmd.Parameters.Add(new SqlParameter("@papellido_Paterno", iUDUsuario.ApelliPaterno == null ? null : iUDUsuario.ApelliPaterno.Trim()));
                cmd.Parameters.Add(new SqlParameter("@papellido_Materno", iUDUsuario.ApelliMaterno == null ? null : iUDUsuario.ApelliMaterno.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pcorreo_Electronico", iUDUsuario.CorreElectronico == null ? null : iUDUsuario.CorreElectronico.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pclave", iUDUsuario.Clave));
                cmd.Parameters.Add(new SqlParameter("@ptoken", iUDUsuario.Token));
                cmd.Parameters.Add(new SqlParameter("@paccion", Accion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Tipo = Accion;
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
        public CenControlError ValidadUsuario(LoginRequest loginRequest)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerUsuario", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pcorreo_Electronico", loginRequest.CorreoElectronico == null ? null : loginRequest.CorreoElectronico.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pclave", loginRequest.Clave));

                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Codigo = reader["CODIGO"].ToString();
                        response.Descripcion = reader["MENSAJE"].ToString();
                        response.Objeto = new UsuarioResponse
                        {
                            Id = int.Parse(reader["ID"].ToString()),
                            Codigo = reader["CODIGO"].ToString(),
                            Nombre = reader["NOMBRE"].ToString(),
                            ApellidoPaterno = reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = reader["APELLIDO_MATERNO"].ToString(),
                            CorreoElectronico = reader["CORREO_ELECTRONICO"].ToString()
                        };
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
        public CenControlError InsertToken(InsertTokenRequest insertTokenRequest)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_insertToken", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pcorreo_Usuario", insertTokenRequest.Correo == null ? null : insertTokenRequest.Correo.Trim()));
                cmd.Parameters.Add(new SqlParameter("@ptoken", insertTokenRequest.Token));

                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Codigo = reader["CODIGO"].ToString();
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
