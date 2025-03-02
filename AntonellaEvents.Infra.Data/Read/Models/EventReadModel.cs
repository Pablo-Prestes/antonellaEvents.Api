namespace AntonellaEvents.Infra.Data.Read.Models
{
    public class EventReadModel : ReadBaseEntity
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsPublic { get; set; }
		public string ZipCode { get; set; }
		public string Street { get; set; }
		public string Number { get; set; }
		public string? Complement { get; set; }
		public string City { get; set; }
		public string State { get; set; }
	}
}
