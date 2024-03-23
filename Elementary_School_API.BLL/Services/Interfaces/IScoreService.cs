using Elementary_School_API.Domain.DTOs.Score;
using Elementary_School_API.Domain.DTOs.Student;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.Domain.Interfaces;

namespace Elementary_School_API.BLL.Services.Interfaces;

public interface IScoreService 
{

	Task<List<ScoreDto>?> GetStudentsScoresAsync(int studentId);

	Task<int> CreateOrUpdateAsync(ScoreDto dto);

	Task<ScoreDto?> RetrieveAsync(int studentId,int quarter);

	Task<bool> ScoreExistsById(int id);

	Task<bool> DeleteAsync(int id);
}