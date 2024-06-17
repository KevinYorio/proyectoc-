using SistemaGestionEntities.models;
using Sistemadegestion.Controllers;
using System;
using System.Collections.Generic;

namespace SistemaGestionUI
{
    public class InterfazUsuario
    {
        public void MostrarMenuPrincipal()
        {
            Console.WriteLine("Bienvenido al sistema de gestión.");
            Console.WriteLine("1. Gestionar Usuarios");
            Console.WriteLine("2. Gestionar Productos");
            Console.WriteLine("3. Gestionar Ventas");
            Console.WriteLine("4. Salir");
        }

        public void MostrarMenuGestionUsuarios()
        {
            Console.WriteLine("Gestión de Usuarios:");
            Console.WriteLine("1. Listar Usuarios");
            Console.WriteLine("2. Agregar Usuario");
            Console.WriteLine("3. Eliminar Usuario");
            Console.WriteLine("4. Modificar Usuario");
            Console.WriteLine("5. Volver al Menú Principal");
        }

        public void MostrarMenuGestionProductos()
        {
            Console.WriteLine("Gestión de Productos:");
            Console.WriteLine("1. Listar Productos");
            Console.WriteLine("2. Agregar Producto");
            Console.WriteLine("3. Eliminar Producto");
            Console.WriteLine("4. Modificar Producto");
            Console.WriteLine("5. Volver al Menú Principal");
        }

        public void MostrarMenuGestionVentas()
        {
            Console.WriteLine("Gestión de Ventas:");
            Console.WriteLine("1. Listar Ventas");
            Console.WriteLine("2. Registrar Venta");
            Console.WriteLine("3. Eliminar Venta");
            Console.WriteLine("4. Modificar Venta");
            Console.WriteLine("5. Volver al Menú Principal");
        }

        public void MostrarMensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {mensaje}");
            Console.ResetColor();
        }

        public void MostrarMensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Éxito: {mensaje}");
            Console.ResetColor();
        }

        public void GestionarUsuarios()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenuGestionUsuarios();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarUsuarios();
                        break;
                    case "2":
                        AgregarUsuario();
                        break;
                    case "3":
                        EliminarUsuario();
                        break;
                    case "4":
                        ModificarUsuario();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        MostrarMensajeError("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        public void GestionarProductos()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenuGestionProductos();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarProductos();
                        break;
                    case "2":
                        AgregarProducto();
                        break;
                    case "3":
                        EliminarProducto();
                        break;
                    case "4":
                        ModificarProducto();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        MostrarMensajeError("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        public void GestionarVentas()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenuGestionVentas();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarVentas();
                        break;
                    case "2":
                        RegistrarVenta();
                        break;
                    case "3":
                        EliminarVenta();
                        break;
                    case "4":
                        ModificarVenta();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        MostrarMensajeError("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        private void ListarUsuarios()
        {
            List<Usuario> usuarios = UsuarioController.ListarUsuarios();
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.Id}, Nombre: {usuario.Nombre}, Apellido: {usuario.Apellido}, Usuario: {usuario.NombreUsuario}, Email: {usuario.Mail}");
            }
        }

        private void AgregarUsuario()
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("Ingrese el nombre:");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido:");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre de usuario:");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese la contraseña:");
            usuario.Contraseña = Console.ReadLine();
            Console.WriteLine("Ingrese el email:");
            usuario.Mail = Console.ReadLine();

            UsuarioController.CrearUsuario(usuario);
            MostrarMensajeExito("Usuario creado exitosamente.");
        }

        private void EliminarUsuario()
        {
            Console.WriteLine("Ingrese el ID del usuario a eliminar:");
            int id = int.Parse(Console.ReadLine());

            UsuarioController.EliminarUsuario(id);
            MostrarMensajeExito("Usuario eliminado exitosamente.");
        }

        private void ModificarUsuario()
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("Ingrese el ID del usuario a modificar:");
            usuario.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre:");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido:");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre de usuario:");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese la contraseña:");
            usuario.Contraseña = Console.ReadLine();
            Console.WriteLine("Ingrese el email:");
            usuario.Mail = Console.ReadLine();

            UsuarioController.ModificarUsuario(usuario);
            MostrarMensajeExito("Usuario modificado exitosamente.");
        }

        private void ListarProductos()
        {
            List<Producto> productos = ProductoController.ListarProductos();
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id}, Descripción: {producto.Descripciones}, Costo: {producto.Costo}, Precio Venta: {producto.PrecioVenta}, Stock: {producto.Stock}, ID Usuario: {producto.IdUsuario}");
            }
        }

        private void AgregarProducto()
        {
            Producto producto = new Producto();
            Console.WriteLine("Ingrese la descripción:");
            producto.Descripciones = Console.ReadLine();
            Console.WriteLine("Ingrese el costo:");
            producto.Costo = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el precio de venta:");
            producto.PrecioVenta = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el stock:");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del usuario:");
            producto.IdUsuario = int.Parse(Console.ReadLine());

            ProductoController.CrearProducto(producto);
            MostrarMensajeExito("Producto creado exitosamente.");
        }

        private void EliminarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto a eliminar:");
            int id = int.Parse(Console.ReadLine());

            ProductoController.EliminarProducto(id);
            MostrarMensajeExito("Producto eliminado exitosamente.");
        }

        private void ModificarProducto()
        {
            Producto producto = new Producto();
            Console.WriteLine("Ingrese el ID del producto a modificar:");
            producto.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la descripción:");
            producto.Descripciones = Console.ReadLine();
            Console.WriteLine("Ingrese el costo:");
            producto.Costo = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el precio de venta:");
            producto.PrecioVenta = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el stock:");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del usuario:");
            producto.IdUsuario = int.Parse(Console.ReadLine());

            ProductoController.ModificarProducto(producto);
            MostrarMensajeExito("Producto modificado exitosamente.");
        }

        private void ListarVentas()
        {
            List<Venta> ventas = VentaController.ListarVentas();
            foreach (var venta in ventas)
            {
                Console.WriteLine($"ID: {venta.Id}, Comentarios: {venta.Comentarios}, ID Usuario: {venta.IdUsuario}");
            }
        }

        private void RegistrarVenta()
        {
            Venta venta = new Venta();
            Console.WriteLine("Ingrese los comentarios:");
            venta.Comentarios = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del usuario:");
            venta.IdUsuario = int.Parse(Console.ReadLine());

            VentaController.RegistrarVenta(venta);
            MostrarMensajeExito("Venta registrada exitosamente.");
        }

        private void EliminarVenta()
        {
            Console.WriteLine("Ingrese el ID de la venta a eliminar:");
            int id = int.Parse(Console.ReadLine());

            VentaController.EliminarVenta(id);
            MostrarMensajeExito("Venta eliminada exitosamente.");
        }

        private void ModificarVenta()
        {
            Venta venta = new Venta();
            Console.WriteLine("Ingrese el ID de la venta a modificar:");
            venta.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese los comentarios:");
            venta.Comentarios = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del usuario:");
            venta.IdUsuario = int.Parse(Console.ReadLine());

            VentaController.ModificarVenta(venta);
            MostrarMensajeExito("Venta modificada exitosamente.");
        }
    }
}
