using MediatR;
using AntonellaEvents.Domain.Responses;
using AntonellaEvents.Application.Dtos.Adress;
using AntonellaEvents.Application.Dtos.Event;

namespace AntonellaEvents.Application.Commands.Events
{
	public class CreateEventCommand : IRequest<ApiResponse<Guid>>
	{
		public EventResponseDto eventResponseDto { get; set; }
		public AdressResponseDto adressResponseDto { get; set; }
	}
}
