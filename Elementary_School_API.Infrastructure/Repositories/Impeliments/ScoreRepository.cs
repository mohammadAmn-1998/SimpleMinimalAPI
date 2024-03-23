using Elementary_School_API.Domain.Context;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.Infrastructure.Repositories.Interfaces;
using Elementary_School_API.Infrastructure.RepositoryImpeliment;

namespace Elementary_School_API.Infrastructure.Repositories.Impeliments;

public class ScoreRepository : Repository<Score> , IScoreRepository
{
	
	private readonly AppDbContext _context;

	public ScoreRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}
}