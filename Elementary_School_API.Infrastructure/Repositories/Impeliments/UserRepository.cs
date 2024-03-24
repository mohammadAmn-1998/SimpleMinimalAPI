using Elementary_School_API.Domain.Context;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.Infrastructure.Repositories.Interfaces;
using Elementary_School_API.Infrastructure.RepositoryImpeliment;

namespace Elementary_School_API.Infrastructure.Repositories.Impeliments;

public class UserRepository : Repository<User> , IUserRepository
{


	private readonly AppDbContext _appDbContext;

	public UserRepository( AppDbContext appDbContext) : base(appDbContext)
	{
		_appDbContext = appDbContext;
	}




}