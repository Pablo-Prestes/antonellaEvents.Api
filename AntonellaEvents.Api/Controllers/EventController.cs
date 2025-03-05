using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AntonellaEvents.Application.Commands.Events;
using ADoJob.Domain.Responses;

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
			ApiResponse<Guid> response = await _mediator.Send(createEventCommand);

			return StatusCode(response.StatusCode, response);
		}
	}
}
