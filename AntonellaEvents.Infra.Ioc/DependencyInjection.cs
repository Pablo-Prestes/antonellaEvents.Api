using AntonellaEvents.Domain.Interfaces;
using AntonellaEvents.Infra.Data.Context;
using AntonellaEvents.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AntonellaEvents.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInsfrastructure(this IServiceCollection services,
			IConfiguration configuration)
		{

			#region Conexão com a database

			services.AddDbContext<AntonellaEventsWriteContext>(options =>
					options.UseMySql(
						configuration.GetConnectionString("AntonellaEventsWriteConnection")!,
						new MySqlServerVersion(new Version(8, 0, 21)),
						b => b.MigrationsAssembly(typeof(AntonellaEventsWriteContext).Assembly.FullName)
					)
			);

			services.AddDbContext<AntonellaEventsReadContext>(options =>
					options.UseMySql(
						configuration.GetConnectionString("AntonellaEventsReadConnection")!,
						new MySqlServerVersion(new Version(8, 0, 21)),
						b => b.MigrationsAssembly(typeof(AntonellaEventsReadContext).Assembly.FullName)
					)
			);
			#endregion

			#region Services
			#endregion

			#region Repositories
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			#endregion

			return services;
		}
	}
}