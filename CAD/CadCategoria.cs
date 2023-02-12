﻿using Microsoft.AspNetCore.Http.Headers;
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

namespace CAD
{
    public class CadCategoria
    {
        public CenControlError listarCategoria(ListarCategoriaRequest request)
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
                cmd.Parameters.AddWithValue("@codCat", request.codigo);
                cmd.Parameters.AddWithValue("@nomCat", request.nombre);
                cmd.Parameters.AddWithValue("@tipoBusqu", request.tipoBusqueda);
                cmd.Parameters.AddWithValue("@page", request.pagina);
                cmd.Parameters.AddWithValue("@count", request.cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(
                            new CenCategoria()
                            {
                                id = Int32.Parse(reader["idCategoria"].ToString()),
                                codigo = reader["codCategoria"].ToString(),
                                nombre = reader["nomCategoria"].ToString()
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
    }
}
