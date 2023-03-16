using Microsoft.AspNetCore.Http.Headers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CEN.Helpers;

namespace CAD
{
    public class CadControlError
    {
        public CenControlError RegistrarControlError(CenControlError request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd; // comando para certificado
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_insertControlError", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@ptipoError", request.Tipo));
                cmd.Parameters.Add(new SqlParameter("@pdescripcion", request.Descripcion));
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Tipo = reader["CODIGO"].ToString();
                        response.Descripcion = reader["DESCRIPCION"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlConexion.Close();
            }
            return response;
        }
    }
}
