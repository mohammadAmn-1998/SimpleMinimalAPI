using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.Domain.DTOs.Student;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.Domain.Interfaces;

namespace Elementary_School_API.Infrastructure.Repositories.Interfaces
{
	public interface IStudentRepository : IRepository<Student>
	{

	}
}
