using AntonellaEvents.Domain.Entities.EntitiesWrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntonellaEvents.Infra.Data.EntitiesConfiguration.EntitiesConfigurationWrite
{
	internal class EventsConfiguration : IEntityTypeConfiguration<Events>
	{
		public void Configure(EntityTypeBuilder<Events> builder)
		{
			builder.HasKey(e => e.Id);
	
			builder.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(e => e.Description)
				.IsRequired()
				.HasMaxLength(500);

			builder.Property(e => e.StartDate)
				.IsRequired();

			builder.Property(e => e.EndDate)
				.IsRequired();
		

			builder.Property(e => e.IsPublic)
				.IsRequired();

			builder.HasOne(e => e.Address)
				.WithOne(a => a.Events) 
				.HasForeignKey<Events>(e => e.AddressId)
				.IsRequired();

			builder.HasQueryFilter(e => e.Active);
		}
	}
}
