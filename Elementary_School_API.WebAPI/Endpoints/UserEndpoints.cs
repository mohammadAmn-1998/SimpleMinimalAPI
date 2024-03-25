using Elementary_School_API.BLL.Helpers;
using Elementary_School_API.BLL.Services.Interfaces;
using Elementary_School_API.Domain.DTOs.User;
using Elementary_School_API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Elementary_School_API.WebAPI.Endpoints;

public static class UserEndpoints
{

	public static async Task<IResult> RegisterAsync([FromForm] User user, IUserService service)
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
	}

	public static async Task<IResult> LoginAsync([FromForm] LoginUserDto userDto, IUserService service, IConfiguration configuration)
	{
		if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Password))
			return Results.ValidationProblem(new Dictionary<string, string[]>(),
				detail: "userName or Password must be not empty!", statusCode: (int)HttpStatusCode.BadRequest);


		var currentUser = await service.GetUserByUserNameAndPassword(userDto.UserName!, userDto.Password!);
		if (currentUser == null) return Results.NotFound();

		var jwt = JwtTokenGenerator.GenerateJwtIdentityToken(configuration, currentUser.UserName!);

		return jwt == null ? Results.StatusCode(StatusCodes.Status500InternalServerError) : Results.Ok(jwt);
	}
}