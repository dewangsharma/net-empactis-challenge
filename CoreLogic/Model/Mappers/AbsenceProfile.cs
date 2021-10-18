using AutoMapper;
using Core.Model.Dto;
using CoreLogic.Model.Objects.Entities;

namespace Core.Model.Mappers
{
    public class AbsenceProfile : Profile, IMap
    {
        public AbsenceProfile( )
        {
            // Absence -> AbsenceDTO
            CreateMap<Absence, AbsenceDto>();
        }
    }
}
