using AutoMapper;
using Productos.Domain.DTO;
using Productos.Domain.Entities;

namespace Productos.Domain.Mappers
{
    public class UnidadMedidaMapper : Profile
    {
        public UnidadMedidaMapper()
        {
            CreateMap<UnidadMedida, UnidadMedidaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => string.Format("{0} - {1}", src.Nombre, src.Codigo)));
        }
    }
}
