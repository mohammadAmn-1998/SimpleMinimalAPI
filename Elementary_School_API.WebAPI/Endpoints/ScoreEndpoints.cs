using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.BLL.Services.Interfaces;
using Elementary_School_API.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Elementary_School_API.WebAPI.Endpoints;

public static class ScoreEndpoints
{

	public static async Task<IResult> GetAllAsync([FromRoute] int id, IScoreService scoreService)
	{
		var scores = await scoreService.GetStudentsScoresAsync(id);

		return scores == null ? Results.NotFound() : Results.Ok(scores);
	}

	public static async Task<IResult> RetrieveAsync([FromRoute] int id, [FromRoute] int quarter,
		IScoreService scoreService)
	{

		var score = await scoreService.RetrieveAsync(id, quarter);

		return score == null ? Results.NotFound() : Results.Ok(score);

	}

	public static async Task<IResult> CreateAsync([FromRoute] int id, [FromForm] Score score,
		IScoreService scoreService, [FromServices] IValidator<Score> validator, IScoreMapper mapper)
	{

		var validationResult = await validator.ValidateAsync(score);

		if (!validationResult.IsValid)
			return Results.ValidationProblem(validationResult.ToDictionary(),
				statusCode: (int)HttpStatusCode.BadRequest);

		if (await scoreService.RetrieveAsync(id, (int)score.Quarter) != null)
			return Results.Problem(detail: $"This score for quarter : {score.Quarter} is already exists!",
				statusCode: StatusCodes.Status409Conflict);

		return score.Id != 0
			? Results.BadRequest()
			: Results.CreatedAtRoute("scoreByQuarter",
				new { id = await scoreService.CreateOrUpdateAsync(mapper.Map(score)!), quarter = (int)score.Quarter });
	}

	public static async Task<IResult> UpdateOrCreateAsync([FromRoute] int id, [FromForm] Score score,
		IScoreMapper mapper, IValidator<Score> validator, IScoreService scoreService)
	{

		var validationResult = await validator.ValidateAsync(score);

		if (!validationResult.IsValid)
			return Results.ValidationProblem(validationResult.ToDictionary(),
				statusCode: (int)HttpStatusCode.BadRequest);

		switch (score.Id)
		{
			case > 0:
			{
				var scoreAlreadyExists = await scoreService.ScoreExistsById(score.Id);

				if (scoreAlreadyExists)
				{
					var result = await scoreService.CreateOrUpdateAsync(mapper.Map(score)!);

					return Results.NoContent();

				}

				return Results.Problem("Score With this id is not exists!", statusCode:
					StatusCodes.Status400BadRequest);
			}
			case 0:
				await scoreService.CreateOrUpdateAsync(mapper.Map(score)!);
				return Results.CreatedAtRoute("scoreByQuarter", new { id = id, quarter = (int)score.Quarter });
			default:
				return Results.Problem("id is invalid", statusCode: StatusCodes.Status400BadRequest);
		}
	}

		public static async Task<IResult> DeleteAsync([FromRoute] int id, int quarter, IScoreService service)
		{

			if (id == 0)
				return Results.BadRequest();

			var score = await service.RetrieveAsync(id, quarter);

			if (score == null)
				return Results.BadRequest();

			var isDeleted = await service.DeleteAsync(score.Id);

			return isDeleted ? Results.NoContent() : Results.StatusCode(StatusCodes.Status500InternalServerError);

		}

}
