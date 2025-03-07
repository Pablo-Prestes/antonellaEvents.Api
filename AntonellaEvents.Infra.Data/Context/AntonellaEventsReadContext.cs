using Microsoft.EntityFrameworkCore;
using AntonellaEvents.Infra.Data.Read.Models;

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
			typeof(AntonellaEventsReadContext).Assembly, t => t.Namespace == "AntonellaEvents.Infra.Data.Read.ReadEntitiesConfiguration");

			base.OnModelCreating(modelBuilder);
		}
	}
}
