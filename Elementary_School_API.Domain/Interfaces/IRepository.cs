using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_School_API.Domain.Interfaces
{
	public interface IRepository<T>
	{

		Task<List<T>?> GetAllAsync(bool eager);

		Task<int> CreateAsync(T entity);

		Task<int> UpdateAsync(T entity);

		Task<int> DeleteAsync(T entity);

		Task<T?> GetByIdAsync(int id,bool eager);
	}
}
