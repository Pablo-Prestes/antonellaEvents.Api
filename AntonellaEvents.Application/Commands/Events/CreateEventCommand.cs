using MediatR;
using AntonellaEvents.Domain.Responses;
using AntonellaEvents.Application.Dtos.Adress;
using AntonellaEvents.Application.Dtos.Event;

namespace AntonellaEvents.Application.Commands.Events
{
	public class CreateEventCommand : IRequest<ApiResponse<EventResponseDto>>
	{
		public EventRequestDto eventRequestDto { get; set; }
		public AdressRequestDto adressRequestDto { get; set; }
	}
}
