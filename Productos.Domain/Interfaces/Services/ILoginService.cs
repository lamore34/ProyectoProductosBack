using Microsoft.Extensions.Configuration;
using Productos.Domain.Entities;

namespace Productos.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        string GenerarToken(string usuario, string idUsuario);
        Task<Usuario> LoginUsuario(string usuario, string clave);
    }
}
