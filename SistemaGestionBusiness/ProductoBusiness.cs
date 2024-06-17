using SistemaGestionEntities.models;
using SistemaGestionData.data;
using System;
using System.Collections.Generic;

namespace SistemaGestionBusiness
{
    public static class ProductoBusiness
    {
        public static Producto ObtenerProducto(int id)
        {
            try
            {
                return ProductoData.ObtenerProducto(id);
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al obtener el producto.");
                throw new Exception("Error al obtener el producto", ex);
            }
        }

        public static void CrearProducto(Producto producto)
        {
            if (ValidarProducto(producto))
            {
                try
                {
                    ProductoData.CrearProducto(producto);
                }
                catch (Exception ex)
                {
                    LoggingService.LogError(ex, "Error al crear el producto.");
                    throw new Exception("Error al crear el producto", ex);
                }
            }
            else
            {
                throw new ArgumentException("El producto no es válido.");
            }
        }

        public static List<Producto> ListarProductos()
        {
            try
            {
                return ProductoData.ListarProductos();
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al listar los productos.");
                throw new Exception("Error al listar los productos", ex);
            }
        }

        public static void EliminarProducto(int id)
        {
            try
            {
                ProductoData.EliminarProducto(id);
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex, "Error al eliminar el producto.");
                throw new Exception("Error al eliminar el producto", ex);
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            if (ValidarProducto(producto))
            {
                try
                {
                    ProductoData.ModificarProducto(producto);
                }
                catch (Exception ex)
                {
                    LoggingService.LogError(ex, "Error al modificar el producto.");
                    throw new Exception("Error al modificar el producto", ex);
                }
            }
            else
            {
                throw new ArgumentException("El producto no es válido.");
            }
        }

        private static bool ValidarProducto(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Descripciones))
            {
                LoggingService.LogInfo("El campo Descripciones es obligatorio.");
                return false;
            }

            if (producto.Costo <= 0)
            {
                LoggingService.LogInfo("El costo debe ser mayor que cero.");
                return false;
            }

            if (producto.PrecioVenta <= 0)
            {
                LoggingService.LogInfo("El precio de venta debe ser mayor que cero.");
                return false;
            }

            if (producto.Stock < 0)
            {
                LoggingService.LogInfo("El stock no puede ser negativo.");
                return false;
            }

            if (producto.IdUsuario <= 0)
            {
                LoggingService.LogInfo("El ID de usuario debe ser válido.");
                return false;
            }

            return true;
        }
    }
}
