using AutoMapper;
using Desafio2_DES.Entities.DTO;
using Desafio2_DES.Entities.Models;

namespace Desafio2_DES.BL.Profiles
{
    public class EventoProfile : Profile
    {
        public EventoProfile() 
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.CodigoEvento, opt => opt.MapFrom(src => src.IdEvento))
                .ForMember(dest => dest.NombreEvento, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.FechaEvento, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.LugarEvento, opt => opt.MapFrom(src => src.Lugar))
                .ReverseMap();
        }
    }
}
