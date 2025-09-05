using Productos.Domain.Entities;

namespace Productos.Domain.Interfaces.Repositories
{
    public interface IUnidadMedidaRepository
    {
        Task<IList<UnidadMedida>> GetAll();
    }
}
