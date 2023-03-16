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

namespace CAD
{
    public class CadUsuario
    {
        public CenControlError IUDUsuario(IUDUsuario iUDUsuario, string acccion)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudUsuario", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid", iUDUsuario.id));
                cmd.Parameters.Add(new SqlParameter("@pnumero_Documento", iUDUsuario.numerDocumento == null ? null : iUDUsuario.numerDocumento.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pnombre", iUDUsuario.nombreCompleto == null ? null : iUDUsuario.nombreCompleto.Trim()));
                cmd.Parameters.Add(new SqlParameter("@papellido_Paterno", iUDUsuario.apelliPaterno == null ? null : iUDUsuario.apelliPaterno.Trim()));
                cmd.Parameters.Add(new SqlParameter("@papellido_Materno", iUDUsuario.apelliMaterno == null ? null : iUDUsuario.apelliMaterno.Trim() ));
                cmd.Parameters.Add(new SqlParameter("@pcorreo_Electronico", iUDUsuario.correElectronico == null ? null : iUDUsuario.correElectronico.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pclave", iUDUsuario.clave));
                cmd.Parameters.Add(new SqlParameter("@ptoken", iUDUsuario.token));
                cmd.Parameters.Add(new SqlParameter("@paccion", acccion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.tipo = acccion;
                        response.codigo = reader["CODIGO"].ToString();
                        response.descripcion = reader["MENSAJE"].ToString();
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
            _sqlConexion = new SqlConnection(Constants.cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerUsuario", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pcorreo_Electronico", loginRequest.correoElectronico == null ? null : loginRequest.correoElectronico.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pclave", loginRequest.clave));

                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.codigo = reader["CODIGO"].ToString();
                        response.descripcion = reader["MENSAJE"].ToString();
                        response.objeto = new UsuarioResponse {
                                                Id = int.Parse(reader["ID"].ToString()),
                                                Codigo = reader["CODIGO"].ToString(),
                                                Nombre = reader["NOMBRE"].ToString(),
                                                ApellidoPaterno = reader["APELLIDO_PATERNO"].ToString(),
                                                ApellidoMaterno = reader["APELLIDO_MATERNO"].ToString(),
                                                CorreoElectronico = reader["CORREO_ELECTRONICO"].ToString()};
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
            _sqlConexion = new SqlConnection(Constants.cadena_conexion);
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
                        response.codigo = reader["CODIGO"].ToString();
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
