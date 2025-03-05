using AntonellaEvents.Application.Dtos.Adress;
using AntonellaEvents.Application.Dtos.Event;
using AntonellaEvents.Domain.Entities;
using AutoMapper;

namespace AntonellaEvents.Application.Helpers.Mappings
{
    public class MappingsEntitiesOrDtos : Profile
	{
        public MappingsEntitiesOrDtos() 
        {
			#region Events
			CreateMap<EventResponseDto, Events>().ReverseMap();
			#endregion

			#region Adress
			CreateMap<AdressResponseDto, Address>().ReverseMap();
			#endregion
		}
	}
}
