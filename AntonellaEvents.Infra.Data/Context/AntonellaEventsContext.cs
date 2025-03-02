using AntonellaEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AntonellaEvents.Infra.Data.Context
{
    public class AntonellaEventsContext : DbContext
    {
		public AntonellaEventsContext(DbContextOptions<AntonellaEventsContext> options) : base(options) { }

		public DbSet<Events> Events { get; set; }
		public DbSet<Address> Addresses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AntonellaEventsContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}
	}
}
