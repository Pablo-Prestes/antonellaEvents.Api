using AntonellaEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AntonellaEvents.Infra.Data.EntitiesConfiguration
{
	internal class AddresConfiguration : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.Property(s => s.State)
				.IsRequired()
				.HasMaxLength(2);

			builder.Property(z => z.ZipCode)
				.IsRequired()
				.HasMaxLength(8);

			builder.Property(s => s.Street)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(n => n.Number)
				.IsRequired()
				.HasMaxLength(5);

			builder.Property(c => c.Complement)
				.HasMaxLength(100);

			builder.Property(c => c.City)
				.IsRequired()
				.HasMaxLength(40);

			builder.HasQueryFilter(e => e.Active);
		}
	}
}
