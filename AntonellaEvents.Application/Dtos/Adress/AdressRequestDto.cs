﻿namespace AntonellaEvents.Application.Dtos.Adress
{
    public class AdressRequestDto
    {
		public string ZipCode { get; set; }
		public string Street { get; set; }
		public string Number { get; set; }
		public string? Complement { get; set; }
		public string City { get; set; }
		public string State { get; set; }
	}
}
