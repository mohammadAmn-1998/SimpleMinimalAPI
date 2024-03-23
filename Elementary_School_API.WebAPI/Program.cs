using Elementary_School_API.BLL.Services.SeedWorks.Installer;
using Elementary_School_API.Domain.Context;
using Elementary_School_API.Infrastructure.SeedWorks.Installer;
using Elementary_School_API.WebAPI.RouteGroups;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddRepositories();
builder.Services.AddCustomServices();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.MapGroup("/Students").GroupStudents();

app.UseHttpsRedirection();

app.Run();

