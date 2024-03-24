using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.Domain.Context;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.Domain.Interfaces;
using Elementary_School_API.Infrastructure.Repositories.Interfaces;
using Elementary_School_API.Infrastructure.RepositoryImpeliment;

namespace Elementary_School_API.Infrastructure.Repositories.Impeliments
{
	public class StudentRepository : Repository<Student>, IStudentRepository
	{
		private readonly AppDbContext _appDbContext;

		public StudentRepository( AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}
	}
}
