namespace AntonellaEvents.Application.Dtos.Event
{
	public class EventResponseDto
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public DateTime StartDate { get; private set; }
		public DateTime EndDate { get; private set; }
		public bool IsPublic { get; private set; }
	}
}
