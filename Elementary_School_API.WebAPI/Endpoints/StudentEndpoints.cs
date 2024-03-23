using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.BLL.Services.Interfaces;
using Elementary_School_API.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Elementary_School_API.WebAPI.Endpoints
{
	public static class StudentEndpoints
	{

		public static async Task<IResult> GetAllAsync(IStudentService service)
		{

			var students = await service.GetAllStudentsAsync();

			return students == null ? Results.NoContent() : Results.Ok(students);
		}

		public static async Task<IResult> CreateAsync([FromBody] Student student, IStudentService service, IStudentMapper mapper,
			IValidator<Student> validator)
		{

			var validationResult = await validator.ValidateAsync(student);
			if (!validationResult.IsValid)
			{
				return Results.ValidationProblem(validationResult.ToDictionary(), statusCode: (int)HttpStatusCode.BadRequest);
			}

			var countryId = await service.CreateOrUpdateAsync(mapper.MapToDto(student)!);

			if (countryId <= 0)
			{
				return Results.StatusCode(StatusCodes.Status500InternalServerError);
			}

			return Results.CreatedAtRoute("studentById",
				new { Id = countryId });

		}


		public static async Task<IResult> RetrieveAsync(int id, IStudentService service, IStudentMapper mapper)
		{

			var student = await service.RetrieveAsync(id, false);

			if (student is null)
				return Results.NotFound();

			return Results.Ok(student);

		}

		public static async Task<IResult> UpdateOrCreateAsync([FromForm] Student student,
			IStudentService service, IValidator<Student> validator, IStudentMapper mapper)
		{

			var validationResult = await validator.ValidateAsync(student);

			if (validationResult.IsValid)
			{
				var studentId = await service.CreateOrUpdateAsync(mapper.MapToDto(student)!);

				if (studentId <= 0)
					return Results.StatusCode(StatusCodes.Status500InternalServerError);

				if (student.Id is 0)
					return Results.CreatedAtRoute("studentById", new { id = studentId });

				return Results.NoContent();
			}

			return Results.ValidationProblem(validationResult.ToDictionary(),
				statusCode: StatusCodes.Status400BadRequest);

		}

		public static async Task<IResult> DeleteAsync([FromRoute] int id, IStudentService service)
		{

			if (id == 0)
				return Results.BadRequest();

			var isDeleted = await service.DeleteAsync(id);

			if (isDeleted)
				return Results.NoContent();

			return Results.StatusCode(StatusCodes.Status500InternalServerError);


		}




	}
}
