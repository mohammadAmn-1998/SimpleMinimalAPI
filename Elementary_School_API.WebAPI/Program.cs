using System.Security.Claims;
using System.Text;
using Elementary_School_API.BLL.Services.SeedWorks.Installer;
using Elementary_School_API.Domain.Context;
using Elementary_School_API.Infrastructure.SeedWorks.Installer;
using Elementary_School_API.WebAPI.ExceptionHandlers;
using Elementary_School_API.WebAPI.RouteGroups;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddExceptionHandler<DefaultExceptionHandler>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{

		options.TokenValidationParameters = new TokenValidationParameters
		{

			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidAudience = builder.Configuration["JWT:Audience"],
			ValidIssuer = builder.Configuration["JWT:Issuer"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))

		};
	});
builder.Services.AddAuthorization();
builder.Services.AddRepositories();
builder.Services.AddCustomServices();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseExceptionHandler(options=> {});

app.MapGroup("/Students").GroupStudents().RequireAuthorization();
app.MapGroup("/Users").GroupUsers();



app.UseAuthentication();
app.UseAuthorization();






app.Run();

