using SistemaGestionBusiness;
using SistemaGestionEntities.models;
using System.Collections.Generic;

namespace Sistemadegestion.Controllers
{
    public static class VentaController
    {
        public static Venta ObtenerVenta(int id)
        {
            return VentaBusiness.ObtenerVenta(id);
        }

        public static void RegistrarVenta(Venta venta)
        {
            VentaBusiness.RegistrarVenta(venta);
        }

        public static List<Venta> ListarVentas()
        {
            return VentaBusiness.ListarVentas();
        }

        public static void ModificarVenta(Venta venta)
        {
            VentaBusiness.ModificarVenta(venta);
        }

        public static void EliminarVenta(int id)
        {
            VentaBusiness.EliminarVenta(id);
        }
    }
}
