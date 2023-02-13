using System;
using Upd8.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Upd8.Infra.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext()
		{
		}

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		public DbSet<Customer> Customer { get; set; }
	}
}
