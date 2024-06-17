using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaGestion.Data;

namespace SistemaGestionData.data
{
    public static class UsuarioData
    {
        public static Usuario ObtenerUsuario(int IdUsuario)
        {
            Usuario usuario = null;
            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario WHERE Id=@IdUsuario";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    usuario = new Usuario
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        Nombre = dr["Nombre"].ToString(),
                                        Apellido = dr["Apellido"].ToString(),
                                        NombreUsuario = dr["NombreUsuario"].ToString(),
                                        Contraseña = dr["Contraseña"].ToString(),
                                        Mail = dr["Mail"].ToString()
                                    };
                                }
                            }
                            else
                            {
                                throw new KeyNotFoundException("Usuario no encontrado");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al obtener el usuario por ID.");
                throw;
            }

            return usuario;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var usuario = new Usuario
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        Nombre = dr["Nombre"].ToString(),
                                        Apellido = dr["Apellido"].ToString(),
                                        NombreUsuario = dr["NombreUsuario"].ToString(),
                                        Contraseña = dr["Contraseña"].ToString(),
                                        Mail = dr["Mail"].ToString()
                                    };
                                    lista.Add(usuario);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al listar los usuarios.");
                throw new Exception("Error al listar los usuarios", ex);
            }

            return lista;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            string query = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                        comando.Parameters.AddWithValue("@Mail", usuario.Mail);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al crear el usuario.");
                throw new Exception("Error al crear el usuario", ex);
            }
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            string query = "UPDATE Usuario SET Nombre=@Nombre, Apellido=@Apellido, NombreUsuario=@NombreUsuario, Contraseña=@Contraseña, Mail=@Mail WHERE Id=@Id";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                        comando.Parameters.AddWithValue("@Mail", usuario.Mail);
                        comando.Parameters.AddWithValue("@Id", usuario.Id);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al modificar el usuario.");
                throw new Exception("Error al modificar el usuario", ex);
            }
        }

        public static void EliminarUsuario(int IdUsuario)
        {
            string query = "DELETE FROM Usuario WHERE Id=@IdUsuario";

            try
            {
                using (SqlConnection conexion = ConnectionADO.GetConnection())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al eliminar el usuario.");
                throw new Exception("Error al eliminar el usuario", ex);
            }
        }
    }
}
