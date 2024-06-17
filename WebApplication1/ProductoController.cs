using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities.models;

namespace SistemadegestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoBusiness _productoBusiness;

        public ProductoController(ProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _productoBusiness.ObtenerProductos();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProducto(int id)
        {
            var producto = _productoBusiness.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult CrearProducto([FromBody] Producto producto)
        {
            _productoBusiness.CrearProducto(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }
            _productoBusiness.ActualizarProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            _productoBusiness.EliminarProducto(id);
            return NoContent();
        }
    }
}
