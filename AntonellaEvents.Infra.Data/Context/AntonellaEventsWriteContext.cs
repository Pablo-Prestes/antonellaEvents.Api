﻿using AntonellaEvents.Domain.Entities;
using AntonellaEvents.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace AntonellaEvents.Infra.Data.Context
{
	public class AntonellaEventsWriteContext : DbContext
	{
		public AntonellaEventsWriteContext(DbContextOptions<AntonellaEventsWriteContext> options) : base(options) { }

		public DbSet<Events> Events { get; set; }
		public DbSet<Address> Address { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(
			typeof(AntonellaEventsWriteContext).Assembly, t => t.Namespace == "AntonellaEvents.Infra.Data.EntitiesConfiguration");
			base.OnModelCreating(modelBuilder);
		}
	}
}
