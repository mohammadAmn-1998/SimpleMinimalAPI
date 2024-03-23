using Elementary_School_API.Domain.SeedWorks.Base;

namespace Elementary_School_API.BLL.Services.SeedWorks.Base;

public interface IService<T> where T : EntityBase
{

	Task<List<T>?> GetAllAsync(bool eager);

	Task<int> CreateAsync(T entity);

	Task<int> UpdateAsync(T entity);

	Task<int> DeleteAsync(T entity);

	Task<T?> GetByIdAsync(int id, bool eager);

}