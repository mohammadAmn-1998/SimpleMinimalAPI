using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.BLL.Services.Interfaces;
using Elementary_School_API.BLL.Services.SeedWorks.Base;
using Elementary_School_API.Domain.DTOs.Score;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.Domain.Interfaces;
using Elementary_School_API.Infrastructure.Repositories.Impeliments;
using Elementary_School_API.Infrastructure.Repositories.Interfaces;

namespace Elementary_School_API.BLL.Services.Impeliments;

	 public class ScoreService : Service<Score> , IScoreService

	 {

		private IScoreRepository _scoreRepository;
		private readonly IStudentRepository _studentRepository;
		private IScoreMapper _scoreMapper;

		public ScoreService( IScoreRepository scoreRepository, IStudentRepository studentRepository, IScoreMapper scoreMapper) : base(scoreRepository)
		{
			_scoreRepository = scoreRepository;
			_studentRepository = studentRepository;
			_scoreMapper = scoreMapper;
		}


		public async Task<List<ScoreDto>?> GetStudentsScoresAsync(int studentId)
		{
			var student = await _studentRepository.GetByIdAsync(studentId, true);

			return student?.Scores?.Select(_scoreMapper.Map).ToList()!;

		}

		public async Task<int> CreateOrUpdateAsync( ScoreDto dto)
		{

			if (dto.Id > 0)
			{
				dto.UpdateDate = DateTime.Now;
				var result =  await _scoreRepository.UpdateAsync(_scoreMapper.MapToEntity(dto)!);
				return result > 0 ? dto.Id : 0;
			}

			dto.CreationDate = DateTime.Now;
			dto.UpdateDate = null;
			var scoreId = await _scoreRepository.CreateAsync(_scoreMapper.MapToEntity(dto)!);
			return scoreId;

		}

		public async Task<ScoreDto?> RetrieveAsync(int studentId, int quarter)
		{

			var student = await _studentRepository.GetByIdAsync(studentId, true);

			return student?.Scores?.Select(_scoreMapper.Map).FirstOrDefault(s => (int)s!.Quarter == quarter);

		}

		public async Task<bool> ScoreExistsById(int id)
		{
			return await _scoreRepository.GetByIdAsync(id, false) != null;
		}

		
		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _scoreRepository.GetByIdAsync(id, false);
			if (entity == null) return false;

			var result = await _scoreRepository.DeleteAsync(entity);
			return result == 1;

		}
	
	 }

