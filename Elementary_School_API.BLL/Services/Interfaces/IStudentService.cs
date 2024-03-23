using Elementary_School_API.Domain.DTOs.Student;
using Microsoft.Data.SqlClient.DataClassification;

namespace Elementary_School_API.BLL.Services.Interfaces;

public interface IStudentService
{
	Task<List<StudentDto>?> GetAllStudentsAsync();

	Task<int> CreateOrUpdateAsync(StudentDto dto);

	Task<StudentDto?> RetrieveAsync(int id,bool eager);

	Task<bool> DeleteAsync(int id);
}