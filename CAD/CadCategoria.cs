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

namespace CAD
{
    public class CadCategoria
    {
        public CenControlError ListarCategoria(ListarCategoriaRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.cadena_conexion);
            SqlCommand cmd;
            List<CenCategoria> lista = new List<CenCategoria>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerCategorias", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Categoria", request.codigo == null ? null : request.codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_Categoria", request.nombre == null ? null : request.nombre.Trim());
                cmd.Parameters.AddWithValue("@ptipo_Busqueda", request.tipoBusqueda == null ? null : request.tipoBusqueda.Trim());
                cmd.Parameters.AddWithValue("@ppage", request.pagina);
                cmd.Parameters.AddWithValue("@pcount", request.cantidad);
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
                                Nombre = reader["nombre_Categoria"].ToString()
                            }
                        );
                    }
                }
                response.descripcion = lista.Count == 0 ? "No se encontraron resultados" : "Operacion Exitosa";
                response.tipo = "R";
                response.objeto = lista;
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
            _sqlConexion = new SqlConnection(Constants.cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudCategoria", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Categoria", cenCategoria.id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Categoria", cenCategoria.nombre == null ? null : cenCategoria.nombre.Trim()));
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

        public CenControlError ObtenerCategoria(int id)
        {
            CenControlError response = new();
            SqlConnection _sqlConexion = new(Constants.cadena_conexion);
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

                response.descripcion = string.IsNullOrEmpty(categoria.Codigo) ? "Categoría no encontrada" : "Operacion Exitosa";
                response.tipo = "R";
                response.objeto = categoria;
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
