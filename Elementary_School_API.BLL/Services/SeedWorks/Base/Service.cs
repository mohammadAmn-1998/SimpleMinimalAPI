using Elementary_School_API.Domain.Interfaces;
using Elementary_School_API.Domain.SeedWorks.Base;

namespace Elementary_School_API.BLL.Services.SeedWorks.Base;

public class Service<T> : IService<T> where T : EntityBase
{
	

	private readonly IRepository<T> _repository;


	public Service(IRepository<T> repository)
	{
		_repository = repository;
	}


	public async Task<List<T>?> GetAllAsync(bool eager)
	{
		return await _repository.GetAllAsync(eager);
	}

	public async Task<int> CreateAsync(T entity)
	{
		return await _repository.CreateAsync(entity);
	}

	public async Task<int> UpdateAsync(T entity)
	{
		return await _repository.UpdateAsync(entity);
	}

	public async Task<int> DeleteAsync(T entity)
	{
		return await _repository.DeleteAsync(entity);
	}

	public async Task<T?> GetByIdAsync(int id, bool eager)
	{
		return await _repository.GetByIdAsync(id,eager);
	}
}