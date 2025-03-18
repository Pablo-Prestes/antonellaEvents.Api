namespace AntonellaEvents.Domain.Entities.Read
{
	public class EventReadModel : BaseEntity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public DateTime StartDate { get; private set; }
		public DateTime EndDate { get; private set; }
		public bool IsPublic { get; private set; }
		public string ZipCode { get; private set; }
		public string Street { get; private set; }
		public string Number { get; private set; }
		public string? Complement { get; private set; }
		public string City { get; private set; }
		public string State { get; private set; }

		public EventReadModel(
			Guid uuid,
			string name,
			string description,
			DateTime startDate,
			DateTime endDate,
			bool isPublic,
			string zipCode,
			string street,
			string number,
			string? complement,
			string city,
			string state)
		{
			Uuid = uuid;
			Name = name;
			Description = description;
			StartDate = startDate;
			EndDate = endDate;
			IsPublic = isPublic;
			ZipCode = zipCode;
			Street = street;
			Number = number;
			Complement = complement;
			City = city;
			State = state;
		}
	}
}
