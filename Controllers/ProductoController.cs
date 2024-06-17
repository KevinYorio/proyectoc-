using SistemaGestionBusiness;
using SistemaGestionEntities.models;
using System.Collections.Generic;

namespace Sistemadegestion.Controllers
{
    public static class ProductoController
    {
        public static Producto ObtenerProducto(int id)
        {
            return ProductoBusiness.ObtenerProducto(id);
        }

        public static void CrearProducto(Producto producto)
        {
            ProductoBusiness.CrearProducto(producto);
        }

        public static List<Producto> ListarProductos()
        {
            return ProductoBusiness.ListarProductos();
        }

        public static void ModificarProducto(Producto producto)
        {
            ProductoBusiness.ModificarProducto(producto);
        }

        public static void EliminarProducto(int id)
        {
            ProductoBusiness.EliminarProducto(id);
        }
    }
}
