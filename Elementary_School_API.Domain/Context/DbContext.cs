using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elementary_School_API.Domain.Context
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			
		}


		public DbSet<Student> Students { get; set; }
		public DbSet<Score> Scores { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().HasQueryFilter(s => !s.IsDeleted);
			modelBuilder.Entity<Score>().HasQueryFilter(s => !s.IsDeleted);

			base.OnModelCreating(modelBuilder);
		}
	}
}
