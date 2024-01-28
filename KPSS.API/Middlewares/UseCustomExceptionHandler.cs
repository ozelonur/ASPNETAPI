using System.Text.Json;
using KPSS.Core.DTOs;
using KPSS.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace KPSS.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    CustomResponseDto<NoContentDto> response =
                        CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}