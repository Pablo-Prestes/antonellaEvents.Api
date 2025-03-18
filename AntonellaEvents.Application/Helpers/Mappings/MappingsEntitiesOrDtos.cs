using AntonellaEvents.Application.Dtos.Adress;
using AntonellaEvents.Application.Dtos.Event;
using AntonellaEvents.Domain.Entities.Write;
using AutoMapper;

namespace AntonellaEvents.Application.Helpers.Mappings
{
	public class MappingsEntitiesOrDtos : Profile
	{
		public MappingsEntitiesOrDtos()
		{
			#region Addres
			CreateMap<Address, AdressRequestDto>().ReverseMap();
			CreateMap<Address, AdressResponseDto>().ReverseMap();
			#endregion

			#region Event
			CreateMap<EventRequestDto, Events>()
			.ConstructUsing((src, context) => {
				int addressId = (int)context.Items["AddressId"];
				return new Events(src.Name, src.Description, src.StartDate, src.EndDate, src.IsPublic, addressId);
			});

			CreateMap<Events, EventResponseDto>().ReverseMap();
			#endregion
		}
	}
}
