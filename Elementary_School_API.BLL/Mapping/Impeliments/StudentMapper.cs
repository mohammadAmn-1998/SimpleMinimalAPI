using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.Domain.DTOs.Student;
using Elementary_School_API.Domain.Entities;

namespace Elementary_School_API.BLL.Mapping.Impeliments
{
	public  class StudentMapper :IStudentMapper
	{

		private readonly IScoreMapper _scoreMapper;

		public StudentMapper(IScoreMapper scoreMapper)
		{
			_scoreMapper = scoreMapper;
		}

		public  StudentDto? MapToDto(Student? student)
		{

			return student is not null ? new StudentDto
			{
				Id = student.Id,
				FirstName = student.FirstName?.Trim(),
				LastName = student.LastName?.Trim(),
				CreationDate = student.CreationDate,
				DateOfBirth = student.DateOfBirth,
				NationalCode = student.NationalCode?.Trim(),
				FatherName = student.FatherName?.Trim(),
				StudentNumber = student.StudentNumber,
				UpdateDate = student.UpdateDate,
					
				Scores = student.Scores?.Select(_scoreMapper.Map).ToList(),

			} : null;


		}

		public Student? MapToEntity(StudentDto? dto)
		{
			return dto is not null
				? new Student
				{
					Id = dto.Id,
					CreationDate = dto.CreationDate,
					UpdateDate = dto.UpdateDate,
					IsDeleted = dto.IsDeleted,
					StudentNumber = dto.StudentNumber,
					FirstName = dto.FirstName,
					LastName = dto.LastName,
					FatherName = dto.FatherName,
					DateOfBirth = dto.DateOfBirth,
					NationalCode = dto.NationalCode,
				

				}
				: null;
		}
	}
}
