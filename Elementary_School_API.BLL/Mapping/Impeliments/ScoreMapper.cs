using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.Domain.DTOs.Score;
using Elementary_School_API.Domain.Entities;
using static System.Formats.Asn1.AsnWriter;

namespace Elementary_School_API.BLL.Mapping.Impeliments
{
	public  class ScoreMapper : IScoreMapper
	{

		public  ScoreDto? Map(Score? score)
		{
			return score is not null
				? new ScoreDto
				{
					Id = score.Id,
					StudentId = score.StudentId,
					Art = score.Art,
					Language = score.Language,
					Spelling = score.Spelling,
					Writing = score.Writing,
					PhysicalEducation = score.PhysicalEducation,
					Quarter = score.Quarter,
					Math = score.Math,
					Reading = score.Reading,
					Science = score.Science,
					CreationDate = score.CreationDate,
					UpdateDate = score.UpdateDate,
					IsDeleted = score.IsDeleted,

				}
				: null;
		}

		public Score? MapToEntity(ScoreDto? scoreDto)
		{
			return scoreDto is not null
			? new Score()
			{
					Id = scoreDto.Id,
					StudentId = scoreDto.StudentId,
					Art = scoreDto.Art,
					Language = scoreDto.Language,
					Spelling = scoreDto.Spelling,
				Writing = scoreDto.Writing,
					PhysicalEducation = scoreDto.PhysicalEducation,
					Quarter = scoreDto.Quarter,
					Math = scoreDto.Math,
					Reading = scoreDto.Reading,
				Science = scoreDto.Science,
					CreationDate = scoreDto.CreationDate,
					UpdateDate = scoreDto.UpdateDate,
					IsDeleted = scoreDto.IsDeleted,

			} : null;

		}
	}
}
