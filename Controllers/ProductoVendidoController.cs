using SistemaGestionBusiness;
using SistemaGestionEntities.models;
using System.Collections.Generic;

namespace Sistemadegestion.Controllers
{
    public static class ProductoVendidoController
    {
        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            return ProductoVendidoBusiness.ObtenerProductoVendido(id);
        }

        public static void RegistrarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoBusiness.RegistrarProductoVendido(productoVendido);
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            return ProductoVendidoBusiness.ListarProductosVendidos();
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoBusiness.ModificarProductoVendido(productoVendido);
        }

        public static void EliminarProductoVendido(int id)
        {
            ProductoVendidoBusiness.EliminarProductoVendido(id);
        }
    }
}
