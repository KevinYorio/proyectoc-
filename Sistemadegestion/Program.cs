using System;
using SistemaGestionBusiness;
using SistemaGestionUI;

namespace Sistemadegestion
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfazUsuario interfazUsuario = new InterfazUsuario();
            bool continuar = true;

            while (continuar)
            {
                interfazUsuario.MostrarMenuPrincipal();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        interfazUsuario.GestionarUsuarios();
                        break;
                    case "2":
                        interfazUsuario.GestionarProductos();
                        break;
                    case "3":
                        interfazUsuario.GestionarVentas();
                        break;
                    case "4":
                        continuar = false;
                        Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
                        break;
                    default:
                        interfazUsuario.MostrarMensajeError("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
