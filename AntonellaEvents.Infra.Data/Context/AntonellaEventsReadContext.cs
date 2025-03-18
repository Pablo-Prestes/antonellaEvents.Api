using AntonellaEvents.Domain.Entities.Read;
using Microsoft.EntityFrameworkCore;

namespace AntonellaEvents.Infra.Data.Context
{
	public class AntonellaEventsReadContext : DbContext
	{
		public AntonellaEventsReadContext(DbContextOptions<AntonellaEventsReadContext> options)
			: base(options)
		{
		}

		public DbSet<EventReadModel> Events { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(
			typeof(AntonellaEventsReadContext).Assembly, t => t.Namespace == "AntonellaEvents.Infra.Data.Read.EntitiesConfiguration.EntitiesConfigurationRead");

			base.OnModelCreating(modelBuilder);
		}
	}
}
