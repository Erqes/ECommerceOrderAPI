
using System.Text.Json;
using Microsoft.AspNetCore.Http;


namespace ECommerceOrderAPI.Application
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exceptions.ValidationException ex)
            {

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    Errors = ex.ErrorMessages
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An unexpected error occurred.");
            }
        }
    }

}
