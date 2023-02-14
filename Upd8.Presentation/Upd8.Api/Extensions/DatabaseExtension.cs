using System;
using Microsoft.EntityFrameworkCore;
using Upd8.Infra.Data;

namespace Upd8.Api.Extensions
{
	public static class DatabaseExtension
	{
		public static IServiceCollection AddApplicationDatabase(this WebApplicationBuilder builder)
		{
			return builder.Services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("Application"));
			});
		}
	}
}
