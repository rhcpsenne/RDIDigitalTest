using AutoMapper;
using RDIDigitalTest.Domain.DTOs;
using System;
using Entity = RDIDigitalTest.Domain.Entities;

namespace RDIDigitalTest.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Transforming DTO into Entity object
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CostumerCardTO, Entity.CostumerCard.CostumerCard>()
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
