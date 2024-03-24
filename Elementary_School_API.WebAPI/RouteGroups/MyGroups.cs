using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using Elementary_School_API.BLL.Helpers;
using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.BLL.Services.Interfaces;
using Elementary_School_API.Domain.DTOs.User;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.WebAPI.Endpoints;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Elementary_School_API.WebAPI.RouteGroups
{
	
	public static class MyGroups
	{

		public static RouteGroupBuilder GroupStudents(this RouteGroupBuilder group)
		{

			#region Student

			//GetAll
			group.MapGet("/", StudentEndpoints.GetAllAsync);
			
			//Retrieve
			group.MapGet("/{id}", StudentEndpoints.RetrieveAsync).WithName("studentById");

			//Create
			group.MapPost("/", StudentEndpoints.CreateAsync).DisableAntiforgery();

			//UpdateOrCreate
			group.MapPut("/", StudentEndpoints.UpdateOrCreateAsync).DisableAntiforgery();

			//Delete
			group.MapDelete("/{id}", StudentEndpoints.DeleteAsync);

			#endregion

			#region Scores

			//GetStudentAllScores
			group.MapGet("/{id}/Scores", ScoreEndpoints.GetAllAsync);

			//Retrieve Student Score
			group.MapGet("/{id}/Scores/{quarter}", ScoreEndpoints.RetrieveAsync).WithName("scoreByQuarter");

			//Create Score
			group.MapPost("/{id}/Scores/", ScoreEndpoints.CreateAsync).DisableAntiforgery();

			//Update Score
			group.MapPut("/{id}/Scores/",  ScoreEndpoints.UpdateOrCreateAsync).DisableAntiforgery();

			//Delete Score
			group.MapDelete("/{id}/Scores/{quarter}", ScoreEndpoints.DeleteAsync);

			#endregion

			return group;
		}

		public static RouteGroupBuilder GroupUsers(this RouteGroupBuilder group)
		{
			//Register
			group.MapPost("/", async ([FromForm]User user, IUserService service) =>
			{

				if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
					return Results.ValidationProblem(new Dictionary<string, string[]>(),
						detail: "userName or Password must be not empty!", statusCode: (int)HttpStatusCode.BadRequest);

				var userNameAlreadyExists = await service.CheckUserNameExists(user.UserName!);

				if (userNameAlreadyExists)
					return Results.Problem(detail: "userName already exists!",
						statusCode: StatusCodes.Status409Conflict);

				var userId = await service.CreateUserAsync(new UserDto
				{
					Id = 0,
					UserName = user.UserName,
					Password = user.Password,
					CreationTime = DateTime.Now,
					UpdateTime = null,
					IsDeleted = false
				});

				return userId > 0 ? Results.Created() : Results.StatusCode(StatusCodes.Status500InternalServerError);
			}).DisableAntiforgery();


			//Login 
			group.MapPost("/Login", async ([FromForm] LoginUserDto userDto,IUserService service,IConfiguration configuration) =>
			{
				if(string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Password))
					return Results.ValidationProblem(new Dictionary<string, string[]>(),
						detail: "userName or Password must be not empty!", statusCode: (int)HttpStatusCode.BadRequest);


				var currentUser = await service.GetUserByUserNameAndPassword(userDto.UserName!, userDto.Password!);
				if (currentUser == null) return Results.NotFound();

				var jwt = JwtTokenGenerator.GenerateJwtIdentityToken(configuration, currentUser.UserName!);

				return jwt == null ? Results.StatusCode(StatusCodes.Status500InternalServerError) : Results.Ok(jwt);

			}).DisableAntiforgery();

			return group;
		}



	}
}
