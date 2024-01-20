using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EmployeeManagement.Infrastructure.Middelwares.GlobalExceptionHandlingMiddleware
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        // private readonly ILogger _logger;

        // public GlobalExceptionHandlingMiddleware(ILogger logger) => _logger = logger;
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (EmployeeManagementNotFoundException e)
            {
                await GenerateProblemDetails(
                    e.Message,
                    (int)HttpStatusCode.NotFound,
                    "NotFound Error",
                    context
                );
            }
            catch (EmployeeManagementBadRequestException e)
            {
                await GenerateProblemDetails(
                    e.Message,
                    (int)HttpStatusCode.BadRequest,
                    "Bad Request Error",
                    context
                );
            }
            catch (EmployeeManagementUnAuthorizedException e)
            {
                await GenerateProblemDetails(
                    e.Message,
                    (int)HttpStatusCode.Unauthorized,
                    "Unauthorized Error",
                    context
                );
            }
            catch (EmployeeManagementForbiddenException e)
            {
                await GenerateProblemDetails(
                    e.Message,
                    (int)HttpStatusCode.Forbidden,
                    "Forbidden Error",
                    context
                );
            }
            catch (EmployeeManagementServiceNotFound e)
            {
                await GenerateProblemDetails(
                    e.Message,
                    (int)HttpStatusCode.InternalServerError,
                    "Internal server Error",
                    context
                );
            }
            catch (Exception e)
            {
                await GenerateProblemDetails(
                    e.Message,
                    (int)HttpStatusCode.InternalServerError,
                    "Internal server Error",
                    context
                );
            }
            
        }

        private async Task  GenerateProblemDetails(string errorMessage, int statusCode, string title, HttpContext context)
        {
            context.Response.StatusCode = statusCode;

            ProblemDetails problemDetails = new(){
                    Status = statusCode,
                    Title = title,
                    Detail = errorMessage,
            };

            string json = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}