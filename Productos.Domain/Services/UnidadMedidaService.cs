using AutoMapper;
using Productos.Domain.DTO;
using Productos.Domain.Interfaces.Repositories;
using Productos.Domain.Interfaces.Services;

namespace Productos.Domain.Services
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly IUnidadMedidaRepository _repository;
        private readonly IMapper _mapper;

        public UnidadMedidaService(IUnidadMedidaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IList<UnidadMedidaDto>> GetAll()
        {
            var respuesta = await _repository.GetAll();
            return _mapper.Map<IList<UnidadMedidaDto>>(respuesta);
        }
    }
}
