using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.BLL.Mapping.Impeliments;
using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.BLL.Services.Impeliments;
using Elementary_School_API.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Elementary_School_API.BLL.Services.SeedWorks.Installer
{
	public static class ServiceInstaller
	{

		public static void AddCustomServices(this IServiceCollection services)
		{

			services.AddScoped<IStudentService, StudentService>();
			services.AddScoped<IScoreService, ScoreService>();
			services.AddScoped<IStudentMapper, StudentMapper>();
			services.AddScoped<IScoreMapper, ScoreMapper>();


		}

	}
}
