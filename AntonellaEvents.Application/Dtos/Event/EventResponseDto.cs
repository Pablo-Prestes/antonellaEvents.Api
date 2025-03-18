﻿using AntonellaEvents.Application.Dtos.Adress;

namespace AntonellaEvents.Application.Dtos.Event
{
	public class EventResponseDto
	{
		public string Name { get;  set; }
		public string Description { get;  set; }
		public DateTime StartDate { get;  set; }
		public DateTime EndDate { get;  set; }
		public bool IsPublic { get;  set; }
		public AdressResponseDto? AdressResponseDto { get; set; }
	}
}
