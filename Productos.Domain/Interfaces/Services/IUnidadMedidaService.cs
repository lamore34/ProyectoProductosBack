using Productos.Domain.DTO;

namespace Productos.Domain.Interfaces.Services
{
    public interface IUnidadMedidaService
    {
        Task<IList<UnidadMedidaDto>> GetAll();
    }
}
