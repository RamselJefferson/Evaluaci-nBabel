using AutoMapper;
using Core.Application.Dto;
using Core.Domain.Entities;


namespace Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            // User Mapping
            CreateMap<Orders, OrdersDto>()
                .ReverseMap();
        }
    }
}
