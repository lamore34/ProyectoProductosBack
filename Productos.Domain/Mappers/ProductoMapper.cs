using AutoMapper;
using Productos.Domain.DTO;
using Productos.Domain.Entities;

namespace Productos.Domain.Mappers
{
    public class ProductoMapper : Profile
    {
        public ProductoMapper()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(dest => dest.CodigoProducto, opt => opt.MapFrom(src => src.CodigoProducto))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.ReferenciaInterna, opt => opt.MapFrom(src => src.ReferenciaInterna))
                .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.PrecioUnitario))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado ? "Activo": "Inactivo"))
                .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => string.Format("{0} - {1}", src.UnidadMedida.Nombre, src.UnidadMedida.Codigo)));
        }
    }
}
