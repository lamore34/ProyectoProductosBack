using Productos.Domain.Entities;

namespace Productos.Domain.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        Task<Usuario> GetUsuario(string usuario, string clave);
    }
}
