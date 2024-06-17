using SistemaGestion.Data;
using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaGestionData.data
{
    public static class VentaData
    {
        public static Venta ObtenerVenta(int IdVenta)
        {
            Venta venta = null;
            string query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE Id=@IdVenta";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdVenta", IdVenta);

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    venta = new Venta
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        Comentarios = dr["Comentarios"].ToString(),
                                        IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                                    };
                                }
                            }
                            else
                            {
                                throw new KeyNotFoundException($"Venta con ID {IdVenta} no encontrada.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, $"Error al obtener la venta con ID {IdVenta}: {ex.Message}");
                throw new Exception("Error al obtener la venta: " + ex.Message, ex);
            }

            return venta;
        }

        public static void RegistrarVenta(Venta venta)
        {
            string query = "INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario)";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        comando.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al registrar la venta.");
                throw new Exception("Error al registrar la venta", ex);
            }
        }

        public static List<Venta> ListarVentas()
        {
            List<Venta> ventas = new List<Venta>();
            string query = "SELECT Id, Comentarios, IdUsuario FROM Venta";

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
                                Venta venta = new Venta
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    Comentarios = dr["Comentarios"].ToString(),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                                };
                                ventas.Add(venta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al listar las ventas.");
                throw new Exception("Error al listar las ventas", ex);
            }

            return ventas;
        }

        public static void EliminarVenta(int id)
        {
            string query = "DELETE FROM Venta WHERE Id=@Id";

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
                LoggingService.LogError(ex, "Error al eliminar la venta.");
                throw new Exception("Error al eliminar la venta", ex);
            }
        }

        public static void ModificarVenta(Venta venta)
        {
            string query = "UPDATE Venta SET Comentarios=@Comentarios, IdUsuario=@IdUsuario WHERE Id=@Id";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        comando.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                        comando.Parameters.AddWithValue("@Id", venta.Id);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al modificar la venta.");
                throw new Exception("Error al modificar la venta", ex);
            }
        }
    }
}
