using Productos.Domain.DTO;
using Productos.Domain.Entities;

namespace Productos.Domain.Interfaces.Services
{
    public interface IProductoService
    {
        Task<IList<ProductoDto>> GetProductos(int? codigo = null, string? nombre = null, bool? estado = null, int? idUnidadMedida = null);
        Task<Producto> GetProducto(int codigo);
        Task<bool> Insert(ProductoRequestCrearDto producto);
        Task<bool> Update(ProductoRequestModificarDto producto);
        Task<bool> Delete(int codigo);
    }
}
