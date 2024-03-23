using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.BLL.Mapping.Impeliments;
using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.BLL.Services.Interfaces;
using Elementary_School_API.BLL.Services.SeedWorks.Base;
using Elementary_School_API.Domain.Context;
using Elementary_School_API.Domain.DTOs.Student;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.Domain.Interfaces;
using Elementary_School_API.Infrastructure.Repositories.Impeliments;
using Elementary_School_API.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Elementary_School_API.BLL.Services.Impeliments
{
	public class StudentService :  Service<Student> , IStudentService
	{
		IStudentRepository studentRepository;
		IStudentMapper studentMapper;

		public StudentService(IStudentRepository studentRepository, IStudentMapper studentMapper) : base(studentRepository)
		{
			this.studentRepository = studentRepository;
			this.studentMapper = studentMapper;
		}

		public async Task<List<StudentDto>?> GetAllStudentsAsync()
		{

			
			var students = await studentRepository.GetAllAsync(true);

			return students!.Select(studentMapper.MapToDto).ToList()!;

		}

		public async Task<int> CreateOrUpdateAsync(StudentDto dto)
		{
			var studentId =0;

			if (dto.Id > 0)
			{

				dto.UpdateDate = DateTime.Now;
				 studentId = await studentRepository.UpdateAsync(studentMapper.MapToEntity(dto)!);

				 return studentId;

			}

			dto.StudentNumber = int.Parse("954" + Random.Shared.Next(1, 1000000));
			dto.CreationDate = DateTime.Now;
			dto.UpdateDate = null;
			studentId = await studentRepository.CreateAsync(studentMapper.MapToEntity(dto)!);

			return studentId;
		}

		public async Task<StudentDto?> RetrieveAsync(int id ,bool eager)
		{
			if (id <= 0)
				return null;

			var student = await studentRepository.GetByIdAsync(id, eager);

			return studentMapper.MapToDto(student);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await studentRepository.GetByIdAsync(id, false);
			if (entity == null) return false;

			var result = await studentRepository.DeleteAsync(entity);
			return result == 1;

		}
	}
}
