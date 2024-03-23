using Elementary_School_API.Domain.DTOs.Student;
using Elementary_School_API.Domain.Entities;

namespace Elementary_School_API.BLL.Mapping.Interfaces;

public interface IStudentMapper
{
	StudentDto? MapToDto(Student? student);

	Student? MapToEntity(StudentDto? dto);
}