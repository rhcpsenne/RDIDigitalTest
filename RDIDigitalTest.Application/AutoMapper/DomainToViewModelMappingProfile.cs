using AutoMapper;
using RDIDigitalTest.Application.TransferObjects.CostumerCard;
using RDIDigitalTest.Domain.DTOs;
using Entity = RDIDigitalTest.Domain.Entities;

namespace RDIDigitalTest.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Transforming Entity model into DTO
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Entity.CostumerCard.CostumerCard, CostumerCardTO>();
            CreateMap<Entity.CostumerCard.CostumerCard, ResponseCostumerCardTO>()
                .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RegisteringDate, opt => opt.MapFrom(src => src.RegistrationDate))
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.GetCostumerCardToken()));
        }
    }
}
