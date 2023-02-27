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
                cmd.Parameters.Add(new SqlParameter("@id", iUDUsuario.id));
                cmd.Parameters.Add(new SqlParameter("@numDocumento", iUDUsuario.numerDocumento == null ? null : iUDUsuario.numerDocumento.Trim()));
                cmd.Parameters.Add(new SqlParameter("@nombre", iUDUsuario.nombreCompleto == null ? null : iUDUsuario.nombreCompleto.Trim()));
                cmd.Parameters.Add(new SqlParameter("@apelPater", iUDUsuario.apelliPaterno == null ? null : iUDUsuario.apelliPaterno.Trim()));
                cmd.Parameters.Add(new SqlParameter("@apelMater", iUDUsuario.apelliMaterno == null ? null : iUDUsuario.apelliMaterno.Trim() ));
                cmd.Parameters.Add(new SqlParameter("@corrElect", iUDUsuario.correElectronico == null ? null : iUDUsuario.correElectronico.Trim()));
                cmd.Parameters.Add(new SqlParameter("@clave", iUDUsuario.clave));
                cmd.Parameters.Add(new SqlParameter("@token", iUDUsuario.token));
                cmd.Parameters.Add(new SqlParameter("@accion", acccion));


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
                cmd.Parameters.Add(new SqlParameter("@correoElectro", loginRequest.correoElectronico == null ? null : loginRequest.correoElectronico.Trim()));
                cmd.Parameters.Add(new SqlParameter("@clave", loginRequest.clave));

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
    }
}
