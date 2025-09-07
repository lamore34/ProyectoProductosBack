using Microsoft.AspNetCore.Mvc;
using Productos.Domain.DTO;
using Productos.Domain.Interfaces.Services;

namespace Productos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginService service, ILogger<LoginController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UsuarioDto usuario)
        {
            _logger.LogInformation("Ejecutando operación Login");

            try
            {
                if (usuario == null)
                    return BadRequest("El usuario no puede ser nulo");

                var resultado = await _service.LoginUsuario(usuario.Usuario, usuario.Clave);

                var token = _service.GenerarToken(usuario.Usuario, resultado.IdUsuario);

                return Ok(new { token });
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear producto");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud");
            }
        }
    }
}
