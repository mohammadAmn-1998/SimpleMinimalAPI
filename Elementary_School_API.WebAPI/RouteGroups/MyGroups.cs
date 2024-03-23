using System.Net;
using Elementary_School_API.BLL.Mapping.Interfaces;
using Elementary_School_API.BLL.Services.Interfaces;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.WebAPI.Endpoints;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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



	}
}
