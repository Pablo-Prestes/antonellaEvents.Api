namespace AntonellaEvents.Domain.Entities
{
   public  class Events : BaseEntity
    {
		public int Id { get; set; }
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Location { get; set; }

		public bool IsPublic { get; set; }

		public Address? Address { get; set; }

		public int AddresId { get; set; }
	}
}
