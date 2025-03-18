using MediatR;
using AntonellaEvents.Domain.Responses;
using AntonellaEvents.Application.Commands.Events;
using AntonellaEvents.Domain.Interfaces;
using AutoMapper;
using MassTransit;
using AntonellaEvents.Application.Dtos.Event;
using AntonellaEvents.Application.Dtos.Adress;
using AntonellaEvents.Contracts.Contracts;
using AntonellaEvents.Domain.Entities.Write;

namespace AntonellaEvents.Application.Handlers.Events
{
	public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ApiResponse<EventResponseDto>>
	{
		private readonly IGenericRepository<Domain.Entities.Write.Events> _eventRepository;
		private readonly IGenericRepository<Address> _addressRepository;
		private readonly IMapper _mapper;
		private readonly IBus _buss;
		private const string UserID = "API";

		public CreateEventCommandHandler(
			IGenericRepository<Domain.Entities.Write.Events> eventRepository,
			IGenericRepository<Address> addressRepository,
			IMapper mapper,
			IBus buss)
		{
			_eventRepository = eventRepository;
			_addressRepository = addressRepository;
			_mapper = mapper;
			_buss = buss;
		}

		public async Task<ApiResponse<EventResponseDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			try
			{
				Address newAddress = _mapper.Map<Address>(request.adressRequestDto);

				Address? savedAddress = await _addressRepository.PostAsync(newAddress, UserID);

				Domain.Entities.Write.Events newEvent = _mapper.Map<Domain.Entities.Write.Events>(request.eventRequestDto, opts => opts.Items["AddressId"] = savedAddress.Id);

				Domain.Entities.Write.Events? savedEvent = await _eventRepository.PostAsync(newEvent, UserID);

				EventResponseDto eventResponseDto = _mapper.Map<EventResponseDto>(savedEvent);

				eventResponseDto.AdressResponseDto = _mapper.Map<AdressResponseDto>(savedAddress);

				var eventCreatedMessage = new EventCreated
				{
					Uuid = savedEvent.Uuid,
					Name = savedEvent.Name,
					Description = savedEvent.Description,
					StartDate = savedEvent.StartDate,
					EndDate = savedEvent.EndDate,
					IsPublic = savedEvent.IsPublic,
					ZipCode = savedAddress.ZipCode,
					Street = savedAddress.Street,
					Number = savedAddress.Number,
					Complement = savedAddress.Complement,
					City = savedAddress.City,
					State = savedAddress.State
				};

				await _buss.Publish(eventCreatedMessage);

				return new ApiResponse<EventResponseDto>(true, "Evento criado com sucesso", eventResponseDto, 201);
			}
			catch (Exception ex)
			{
				return new ApiResponse<EventResponseDto>(false, $"Erro ao criar evento: {ex.Message}", 500);
			}
		}
	}
}
