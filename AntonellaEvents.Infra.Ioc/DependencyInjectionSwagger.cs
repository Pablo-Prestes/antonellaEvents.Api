using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AntonellaEvents.Infra.IoC
{
	public static class DependencyInjectionSwagger
	{
		public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Antonella Events Api",
					Version = "v1",
					Description = "Api para gerenciamento de eventos",
					Contact = new OpenApiContact
					{
						Name = "Pablo Henrique da Silva Prestes Neu",
						Email = "pablo.henrique.prestes@gmail.com",
						Url = new Uri("https://www.linkedin.com/in/pablo-henrique-prestes/")
					}
				});

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Please insert JWT with Bearer into field"
				});

				//c.AddSecurityRequirement(new OpenApiSecurityRequirement() Bearer não implementado - Feature: Implementar bearer
				//{
				//	{
				//		new OpenApiSecurityScheme
				//		{
				//			Reference = new OpenApiReference
				//			{
				//				Type = ReferenceType.SecurityScheme,
				//				Id = "Bearer"
				//			},
				//			Scheme = "oauth2",
				//			Name = "Bearer",
				//			In = ParameterLocation.Header,

				//		},
				//		Array.Empty<string>()
				//	}
				//});

				//TODO: LIBERAR ACESSO A CRIACAO DE ARQUIVOS
				//var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				//var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				//c.IncludeXmlComments(xmlPath);
			});
			return services;
		}
	}
}
