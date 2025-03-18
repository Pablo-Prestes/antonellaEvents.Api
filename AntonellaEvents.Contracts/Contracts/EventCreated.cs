﻿namespace AntonellaEvents.Contracts.Contracts
{
	public class EventCreated
	{
		public Guid Uuid { get; set; }
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
