using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.Infrastructure.Repositories.Impeliments;
using Elementary_School_API.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Elementary_School_API.Infrastructure.SeedWorks.Installer
{
	public static class RepositoryInstaller
	{

		public static void AddRepositories(this IServiceCollection services)
		{

			services.AddScoped<IStudentRepository,StudentRepository>();
			services.AddScoped<IScoreRepository, ScoreRepository>();
			services.AddScoped<IUserRepository, UserRepository>();


		}

	}
}
