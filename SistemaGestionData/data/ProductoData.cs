using SistemaGestion.Data;
using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaGestionData.data
{
    public static class ProductoData
    {
        public static Producto ObtenerProducto(int IdProducto)
        {
            Producto producto = null;
            string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto WHERE Id=@IdProducto";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    LoggingService.LogInfo($"Conexión a la base de datos abierta para obtener el producto con ID {IdProducto}.");

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdProducto", IdProducto);

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    producto = new Producto
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        Descripciones = dr["Descripciones"].ToString(),
                                        Costo = Convert.ToDecimal(dr["Costo"]),
                                        PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                        Stock = Convert.ToInt32(dr["Stock"]),
                                        IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                                    };
                                }
                                LoggingService.LogInfo($"Producto con ID {IdProducto} obtenido correctamente.");
                            }
                            else
                            {
                                string notFoundMessage = $"Producto con ID {IdProducto} no encontrado.";
                                LoggingService.LogInfo(notFoundMessage);
                                throw new KeyNotFoundException(notFoundMessage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, $"Error al obtener el producto con ID {IdProducto}: {ex.Message}");
                throw new Exception("Error al obtener el producto: " + ex.Message, ex);
            }

            return producto;
        }

        public static void CrearProducto(Producto producto)
        {
            string query = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                        comando.Parameters.AddWithValue("@Costo", producto.Costo);
                        comando.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        comando.Parameters.AddWithValue("@Stock", producto.Stock);
                        comando.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al crear el producto.");
                throw new Exception("Error al crear el producto", ex);
            }
        }

        public static List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();
            string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Producto producto = new Producto
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    Descripciones = dr["Descripciones"].ToString(),
                                    Costo = Convert.ToDecimal(dr["Costo"]),
                                    PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                    Stock = Convert.ToInt32(dr["Stock"]),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                                };
                                productos.Add(producto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al listar los productos.");
                throw new Exception("Error al listar los productos", ex);
            }

            return productos;
        }

        public static void EliminarProducto(int id)
        {
            string query = "DELETE FROM Producto WHERE Id=@Id";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", id);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al eliminar el producto.");
                throw new Exception("Error al eliminar el producto", ex);
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            string query = "UPDATE Producto SET Descripciones=@Descripciones, Costo=@Costo, PrecioVenta=@PrecioVenta, Stock=@Stock, IdUsuario=@IdUsuario WHERE Id=@Id";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                        comando.Parameters.AddWithValue("@Costo", producto.Costo);
                        comando.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        comando.Parameters.AddWithValue("@Stock", producto.Stock);
                        comando.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                        comando.Parameters.AddWithValue("@Id", producto.Id);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al modificar el producto.");
                throw new Exception("Error al modificar el producto", ex);
            }
        }
    }
}
