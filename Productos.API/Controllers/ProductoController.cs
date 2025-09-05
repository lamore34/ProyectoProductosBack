using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Productos.Domain.DTO;
using Productos.Domain.Interfaces.Services;

namespace Productos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(IProductoService service, ILogger<ProductoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] int? codigo = null,
            [FromQuery] string? nombre = null,
            [FromQuery] bool? estado = null,
            [FromQuery] int? idUnidadMedida = null)
        {
            try
            {
                var productos = await _service.GetProductos(codigo, nombre, estado, idUnidadMedida);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener productos");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud");
            }
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            try
            {
                var productos = await _service.GetProductos(codigo);
                var producto = productos.FirstOrDefault();

                if (producto == null)
                    return NotFound($"No se encontró el producto con codigo = {codigo}");

                return Ok(producto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener producto con codigo = {codigo}");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoRequestCrearDto producto)
        {
            try
            {
                if (producto == null)
                    return BadRequest("El producto no puede ser nulo");

                bool resultado = await _service.Insert(producto);

                if (!resultado)
                    return BadRequest("Error al crear el producto");

                return CreatedAtAction(nameof(Get), new { id = producto.CodigoProducto }, producto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear producto");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud");
            }
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, [FromBody] ProductoRequestModificarDto producto)
        {
            try
            {
                if (producto == null)
                    return BadRequest("No se ha proporcionado el producto");

                bool resultado = await _service.Update(producto);

                if (!resultado)
                    return NotFound($"No se encontró el producto con Codigo = {codigo}");

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar producto con Codigo = {codigo}");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud");
            }
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            try
            {
                if (codigo <= 0)
                    return BadRequest("Debe enviar el codigo del producto");

                bool resultado = await _service.Delete(codigo);

                if (!resultado)
                    return NotFound($"No se encontró el producto con Codigo = {codigo}");

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar producto con Codigo = {codigo}");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud");
            }
        }
    }
}
