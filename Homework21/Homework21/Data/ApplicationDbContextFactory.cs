﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Homework21.Data
{
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var builder = new ConfigurationBuilder();
			builder.SetBasePath(Directory.GetCurrentDirectory());
			builder.AddJsonFile("config.json");
			var config = builder.Build();

			var connectionString = config.GetConnectionString("DefaultConnection");
			optionsBuilder.UseSqlServer(connectionString, opts
				=> opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
			return new ApplicationDbContext(optionsBuilder.Options);
        }
	}
}

