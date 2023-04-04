using CEN.Producto;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using CEN.Response;
using CEN.Categoria;

namespace CAD
{
    public class CadProducto
    {
        public CenControlError ListarProducto(ListarProductoRequest request)
        {
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<ProductoResponse> lista = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerProductos", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Producto", request.Codigo == null ? null : request.Codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_Producto", request.Nombre == null ? null : request.Nombre.Trim());
                cmd.Parameters.AddWithValue("@pprecio_minimo", request.PrecioMinimo == null ? null : request.PrecioMinimo);
                cmd.Parameters.AddWithValue("@pprecio_maximo", request.PrecioMax == null ? null : request.PrecioMax);
                cmd.Parameters.AddWithValue("@pid_categoria", request.idCategoria == null ? null : request.idCategoria);
                cmd.Parameters.AddWithValue("@pid_material", request.idMaterial == null ? null : request.idMaterial);
                cmd.Parameters.AddWithValue("@ppage", request.Pagina);
                cmd.Parameters.AddWithValue("@pcount", request.Cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ProductoResponse
                        {
                            Id = Int32.Parse(reader["id_Producto"].ToString()),
                            Codigo = reader["codigo_Producto"].ToString(),
                            Nombre = reader["nombre_Producto"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Stock = Int32.Parse(reader["stock"].ToString()),
                            Peso = double.Parse(reader["peso"].ToString()),
                            Precio = double.Parse(reader["precio"].ToString()),
                            Estado = reader["estado_Producto"].ToString(),
                            Id_Categoria = Int32.Parse(reader["id_Categoria"].ToString()),
                            NombreCategoria = reader["nombre_Categoria"].ToString(),
                            Etiquetas = this.GetEtiquetaResponseList(reader["etiquetas"].ToString())
                        });
                    }
                }
                response.Descripcion = lista.Count == 0 ? "No se encontraron resultados" : "Operacion Exitosa";
                response.Codigo = "OK";
                response.Tipo = "R";
                response.Objeto = new Paginado
                {
                    Pagina = request.Pagina,
                    Tamanio = request.Cantidad,
                    Total_Resultados = ContarProducto(request),
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
        public CenControlError AgregarProducto(CenAgregarProducto AgregarProducto)
        {
            string accion = "I";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudProducto", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Producto", AgregarProducto.Nombre == null ? null : AgregarProducto.Nombre.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pdescripcion_Producto", AgregarProducto.Descripcion == null ? null : AgregarProducto.Descripcion.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pstock", null));
                cmd.Parameters.Add(new SqlParameter("@ppeso", AgregarProducto.Peso == null ? null : AgregarProducto.Peso));
                cmd.Parameters.Add(new SqlParameter("@pprecio", AgregarProducto.Precio == null ? null : AgregarProducto.Precio));
                cmd.Parameters.Add(new SqlParameter("@pid_categoria", AgregarProducto.id_Categoria == null ? null : AgregarProducto.id_Categoria));
                cmd.Parameters.Add(new SqlParameter("@pids_Etiqueta", AgregarProducto.Ids_etiquetas == null ? null : AgregarProducto.Ids_etiquetas.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pids_Material", AgregarProducto.Ids_porc_material == null ? null : AgregarProducto.Ids_porc_material.Trim()));
                cmd.Parameters.Add(new SqlParameter("@paccion", accion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Codigo = "OK";
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
        public CenControlError EditarProducto(CenEditarProducto EditarProducto)
        {
            string accion = "U";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudProducto", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", EditarProducto.Id == null ? null : EditarProducto.Id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Producto", EditarProducto.Nombre == null ? null : EditarProducto.Nombre.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pdescripcion_Producto", EditarProducto.Descripcion == null ? null : EditarProducto.Descripcion.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pstock", null));
                cmd.Parameters.Add(new SqlParameter("@ppeso", EditarProducto.Peso == null ? null : EditarProducto.Peso));
                cmd.Parameters.Add(new SqlParameter("@pprecio", EditarProducto.Precio == null ? null : EditarProducto.Precio));
                cmd.Parameters.Add(new SqlParameter("@pid_categoria", EditarProducto.id_Categoria == null ? null : EditarProducto.id_Categoria));
                cmd.Parameters.Add(new SqlParameter("@pids_Etiqueta", EditarProducto.ids_etiquetas == null ? null : EditarProducto.ids_etiquetas.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pids_Material", EditarProducto.Ids_porc_material == null ? null : EditarProducto.Ids_porc_material.Trim()));
                cmd.Parameters.Add(new SqlParameter("@paccion", accion));

                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Codigo = "OK";
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
        public CenControlError EliminarProducto(CenEliminarProducto EliminarProducto)
        {
            string accion = "D";
            CenControlError response = new CenControlError();
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_iudProducto", _sqlConexion);
                cmd.Parameters.Add(new SqlParameter("@pid_Producto", EliminarProducto.Id == null ? null : EliminarProducto.Id));
                cmd.Parameters.Add(new SqlParameter("@pnombre_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pdescripcion_Producto", null));
                cmd.Parameters.Add(new SqlParameter("@pstock", null));
                cmd.Parameters.Add(new SqlParameter("@ppeso", null));
                cmd.Parameters.Add(new SqlParameter("@pprecio", null));
                cmd.Parameters.Add(new SqlParameter("@pid_categoria", null));
                cmd.Parameters.Add(new SqlParameter("@pids_Etiqueta", null));
                cmd.Parameters.Add(new SqlParameter("@paccion", accion));


                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Codigo = "OK";
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
        public CenControlError ObtenerProducto(int id)
        {
            CenControlError response = new();
            SqlConnection _sqlConexion = new(Constants.Cadena_conexion);
            SqlCommand cmd;
            ProductoResponse productoResponse = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_obtenerProducto", _sqlConexion);
                cmd.Parameters.AddWithValue("@pid_Producto", id == 0 ? null : id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())

                    if (reader.Read())
                    {
                        productoResponse = new()
                        {
                            Id = Int32.Parse(reader["id_Producto"].ToString()),
                            Codigo = reader["codigo_Producto"].ToString(),
                            Nombre = reader["nombre_Producto"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Stock = Int32.Parse(reader["stock"].ToString()),
                            Peso = double.Parse(reader["peso"].ToString()),
                            Precio = double.Parse(reader["precio"].ToString()),
                            Estado = reader["estado_Producto"].ToString(),
                            Id_Categoria = Int32.Parse(reader["id_Categoria"].ToString()),
                            NombreCategoria = reader["nombre_Categoria"].ToString(),
                            Etiquetas = this.GetEtiquetaResponseList(reader["etiquetas"].ToString())
                        };
                    }

                response.Descripcion = string.IsNullOrEmpty(productoResponse.Codigo) ? "Categoría no encontrada" : "Operacion Exitosa";
                response.Codigo = "OK";
                response.Tipo = "R";
                response.Objeto = productoResponse;
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
        private int ContarProducto(ListarProductoRequest request)
        {
            int total = 0;
            SqlConnection _sqlConexion;
            _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<CenProducto> lista = new List<CenProducto>();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_ContarProductos", _sqlConexion);
                cmd.Parameters.AddWithValue("@pcodigo_Producto", request.Codigo == null ? null : request.Codigo.Trim());
                cmd.Parameters.AddWithValue("@pnombre_Producto", request.Nombre == null ? null : request.Nombre.Trim());
                cmd.Parameters.AddWithValue("@pprecio_minimo", request.PrecioMinimo == null ? null : request.PrecioMinimo);
                cmd.Parameters.AddWithValue("@pprecio_maximo", request.PrecioMax == null ? null : request.PrecioMax);
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
        private List<EtiquetaResponse> GetEtiquetaResponseList(string BDEtiquetas)
        {
            List<EtiquetaResponse> ListEtiquetas = new();
            if (!string.IsNullOrEmpty(BDEtiquetas))
            {
                var Etiquetas = BDEtiquetas.Split("-");
                foreach (var item in Etiquetas)
                {
                    ListEtiquetas.Add(new EtiquetaResponse
                    {
                        Id_Etiqueta = Int32.Parse(item.Split("*")[0]),
                        Nombre_Etiqueta = item.Split("*")[1]
                    });
                }
            }
            return ListEtiquetas;
        }
    }
}
