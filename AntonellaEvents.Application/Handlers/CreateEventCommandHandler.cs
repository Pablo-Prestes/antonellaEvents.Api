using MediatR;
using AntonellaEvents.Domain.Responses;
using AntonellaEvents.Application.Commands.Events;
using AntonellaEvents.Domain.Entities;
using AntonellaEvents.Domain.Interfaces;
using AutoMapper;

namespace AntonellaEvents.Application.Handlers.Events
{
	public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ApiResponse<Guid>>
	{
		private readonly IGenericRepository<Domain.Entities.Events> _eventRepository;
		private readonly IGenericRepository<Address> _addressRepository;
		private readonly IMapper _mapper;

		private const string UserID = "API";

		public CreateEventCommandHandler(
			IGenericRepository<Domain.Entities.Events> eventRepository,
			IGenericRepository<Address> addressRepository,
			IMapper mapper)
		{
			_eventRepository = eventRepository;
			_addressRepository = addressRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			try
			{
				Address newAddress = _mapper.Map<Address>(request.adressResponseDto); 

				var savedAddress = await _addressRepository.PostAsync(newAddress, UserID);

				Domain.Entities.Events newEvent = _mapper.Map<Domain.Entities.Events>(request.eventResponseDto); ;
				newEvent.SetAddress(savedAddress.Id);

				var savedEvent = await _eventRepository.PostAsync(newEvent, UserID);

				return new ApiResponse<Guid>(true, "Evento criado com sucesso", savedEvent.Id);
			}
			catch (Exception ex)
			{
				return new ApiResponse<Guid>(false, $"Erro ao criar evento: {ex.Message}", 500);
			}
		}
	}
}
