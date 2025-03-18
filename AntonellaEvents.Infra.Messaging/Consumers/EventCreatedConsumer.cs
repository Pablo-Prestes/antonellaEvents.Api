using AntonellaEvents.Contracts.Contracts;
using AntonellaEvents.Domain.Entities.Read;
using AntonellaEvents.Domain.Interfaces;
using MassTransit;

namespace AntonellaEvents.Infra.Messaging.Consumers
{
    public class EventCreatedConsumer : IConsumer<EventCreated>
    {
		private readonly IGenericRepository<EventReadModel> _eventRepository;

		public EventCreatedConsumer(IGenericRepository<EventReadModel> eventRepository)
		{
			_eventRepository = eventRepository;
		}

		public async Task Consume(ConsumeContext<EventCreated> context)
        {
			var message = context.Message;

			var readModel = new EventReadModel(
							message.Uuid,
							message.Name,
							message.Description,
							message.StartDate,
							message.EndDate,
							message.IsPublic,
							message.ZipCode,
							message.Street,
							message.Number,
							message.Complement,
							message.City,
							message.State
						);

			await _eventRepository.PostAsync(readModel, "System");
		}
	}
}
