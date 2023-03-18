using Microsoft.AspNetCore.Http.Headers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CEN;
using CEN.Request;
using CEN.Helpers;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using CEN.Categoria;

namespace CAD
{
    public class CadCategoria
    {
        public CenControlError ListarCategoria(ListarCategoriaRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenCategoria> lista = new List<CenCategoria>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerCategorias", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Categoria", request.Codigo == null ? null : request.Codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_Categoria", request.Nombre == null ? null : request.Nombre.Trim());
                cmd.Parameters.AddWithValue("@ppage", request.Pagina);
                cmd.Parameters.AddWithValue("@pcount", request.Cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenCategoria()
                            {
                                Id = Int32.Parse(reader["id_Categoria"].ToString()),
                                Codigo = reader["codigo_Categoria"].ToString(),
                                Nombre = reader["nombre_Categoria"].ToString(),
                                Estado = reader["estado_Categoria"].ToString()
                            }
                        );
                    }
                }
                response.Descripcion = lista.Count == 0 ? "No se encontraron resultados" : "Operacion Exitosa";
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

        public CenControlError IUDCategoria(IUDCategoriaRequest cenCategoria, string acccion)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudCategoria", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Categoria", cenCategoria.Id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Categoria", cenCategoria.Nombre == null ? null : cenCategoria.Nombre.Trim()));
                cmd.Parameters.Add(new SqlParameter("@paccion", acccion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Tipo = acccion;
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

        public CenControlError ObtenerCategoria(int id)
        {
            CenControlError response = new();
            SqlConnection _sqlConexion = new(Constants.Cadena_conexion);
            SqlCommand cmd;
            CenCategoria categoria = new();

            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerCategoria", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_Categoria", id == 0 ? null : id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())

                    if (reader.Read())
                    {
                        categoria.Id = Int32.Parse(reader["id_Categoria"].ToString());
                        categoria.Codigo = reader["codigo_Categoria"].ToString();
                        categoria.Nombre = reader["nombre_Categoria"].ToString();
                        categoria.Estado = reader["estado_Categoria"].ToString();
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
    }
}
