using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Productos.Domain.Interfaces.Services;

namespace Productos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly IUnidadMedidaService _service;
        private readonly ILogger<UnidadMedidaController> _logger;

        public UnidadMedidaController(IUnidadMedidaService service, ILogger<UnidadMedidaController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var productos = await _service.GetAll();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener unidades de medida");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud");
            }
        }
    }
}
