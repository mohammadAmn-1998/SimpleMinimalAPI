using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Elementary_School_API.WebAPI.ExceptionHandlers;

public interface IExceptionHandler
{
	
	ValueTask<bool> TryHandleAsync(HttpContext  context,Exception exception , CancellationToken cancellationToken);

}

public class DefaultExceptionHandler : IExceptionHandler, Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
	{

		await context.Response.WriteAsJsonAsync(new ProblemDetails
		{
			Type = exception.GetType().Name,
			Title = "An unexpected error occurred",
			Status = (int)HttpStatusCode.InternalServerError,
			Detail = exception.Message,
			Instance = $"{context.Request.Method}/{context.Request.Path}",
		}, cancellationToken: cancellationToken);
		return true;
	}
}