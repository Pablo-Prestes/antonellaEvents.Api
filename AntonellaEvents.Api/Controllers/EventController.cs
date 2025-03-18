using MediatR;
using Microsoft.AspNetCore.Mvc;
using AntonellaEvents.Application.Commands.Events;
using AntonellaEvents.Domain.Responses;
using AntonellaEvents.Application.Dtos.Event;

namespace AntonellaEvents.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EventController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateEventCommand createEventCommand)
		{
			ApiResponse<EventResponseDto>? response = await _mediator.Send(createEventCommand);

			return StatusCode(response.StatusCode, response);
		}
	}
}
