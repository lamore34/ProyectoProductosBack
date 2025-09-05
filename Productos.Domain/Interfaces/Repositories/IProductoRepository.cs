using Productos.Domain.DTO;
using Productos.Domain.Entities;

namespace Productos.Domain.Interfaces.Repositories
{
    public interface IProductoRepository
    {
        Task<IList<Producto>> GetProductos(int? codigo = null, string? nombre = null, bool? estado = null, int? idUnidadMedida = null);
        Task<bool> Insert(ProductoRequestCrearDto producto);
        Task<bool> Update(ProductoRequestModificarDto producto);
        Task<bool> Delete(int codigo);
    }
}
