using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AntonellaEvents.Infra.Data.Read.Models;

namespace AntonellaEvents.Infra.Data.EntitiesConfiguration.EntitiesConfigurationRead
{
	public class EventReadModelConfiguration : IEntityTypeConfiguration<EventReadModel>
	{
		public void Configure(EntityTypeBuilder<EventReadModel> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Uuid)
				.IsRequired();

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

			builder.Property(e => e.ZipCode)
				.IsRequired()
				.HasMaxLength(8);

			builder.Property(e => e.Street)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(e => e.Number)
				.IsRequired()
				.HasMaxLength(5);

			builder.Property(e => e.Complement)
				.HasMaxLength(100);

			builder.Property(e => e.City)
				.IsRequired()
				.HasMaxLength(40);

			builder.Property(e => e.State)
				.IsRequired()
				.HasMaxLength(2);
		}
	}
}
