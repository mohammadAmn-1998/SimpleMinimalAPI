using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Elementary_School_API.Domain.Context;
using Elementary_School_API.Domain.Interfaces;
using Elementary_School_API.Domain.SeedWorks.Base;
using Microsoft.EntityFrameworkCore;

namespace Elementary_School_API.Infrastructure.RepositoryImpeliment
{
	public class Repository<T> : IRepository<T> where T : EntityBase
	{

		private readonly AppDbContext _context;

		

		public Repository(AppDbContext context)
		{
			_context = context;
		}

		private DbSet<T> DbSet => _context.Set<T>();

		public async Task<List<T>?> GetAllAsync(bool eager)
		{
			try
			{
				var queryable = DbSet.AsQueryable();

				if (eager)
				{
					foreach (var property in _context.Model.FindEntityType(typeof(T))?.GetNavigations()!)
						queryable = queryable.Include(property.Name);
				}

				return await queryable.ToListAsync();

			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<int> CreateAsync(T entity)
		{
			try
			{

				await DbSet.AddAsync(entity);
				 await _context.SaveChangesAsync();
				 return entity.Id;

			}
			catch (Exception e)
			{
				return 0;
			}
		}

		public async Task<int> UpdateAsync(T entity)
		{
			try
			{
				  DbSet.Update(entity);
				 return await _context.SaveChangesAsync();
				
			}
			catch (Exception e)
			{
				return 0;
			}
		}

		public async Task<int> DeleteAsync(T entity)
		{
			try
			{
				var t = DbSet.First();
				t.IsDeleted = true;

				DbSet.Update(t);
				return await _context.SaveChangesAsync();

			}
			catch (Exception e)
			{
				return 0;
			}
		}

		public async Task<T?> GetByIdAsync(int id, bool eager)
		{
			try
			{
				var queryable = DbSet.Where(e => e.Id == id).AsNoTracking().AsQueryable();

				if (eager)
				{
					foreach (var property in _context.Model.FindEntityType(typeof(T))?.GetNavigations()!)
						queryable = queryable.Include(property.Name);
				}

				return queryable.AsNoTracking().FirstOrDefault();
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}
}
