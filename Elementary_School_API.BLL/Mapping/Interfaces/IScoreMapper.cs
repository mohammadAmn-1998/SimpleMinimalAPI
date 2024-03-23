using Elementary_School_API.Domain.DTOs.Score;
using Elementary_School_API.Domain.Entities;

namespace Elementary_School_API.BLL.Mapping.Interfaces;

public interface IScoreMapper
{
	ScoreDto? Map(Score? score);

	Score? MapToEntity(ScoreDto? scoreDto);
}