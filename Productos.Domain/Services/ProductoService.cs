using AutoMapper;
using Productos.Domain.DTO;
using Productos.Domain.Entities;
using Productos.Domain.Interfaces.Repositories;
using Productos.Domain.Interfaces.Services;

namespace Productos.Domain.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<ProductoDto>> GetProductos(int? codigo = null, string? nombre = null, bool? estado = null, int? idUnidadMedida = null)
        {
            var respuesta = await _repository.GetProductos(codigo, nombre, estado, idUnidadMedida);
            return _mapper.Map<IList<ProductoDto>>(respuesta);
        }
        public async Task<Producto> GetProducto(int codigo)
        {
            var respuesta = await _repository.GetProductos(codigo);
            Producto? producto = respuesta.FirstOrDefault();
            return producto;
        }
        public async Task<bool> Insert(ProductoRequestCrearDto producto)
        {
            bool respuesta = await _repository.Insert(producto);
            return respuesta;
        }
        public async Task<bool> Update(ProductoRequestModificarDto producto)
        {
            bool respuesta = await _repository.Update(producto);
            return respuesta;
        }
        public async Task<bool> Delete(int codigo)
        {
            bool respuesta = await _repository.Delete(codigo);
            return respuesta;
        }
    }
}
