using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTO_s;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
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

                    var exceptiopnFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptiopnFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException =>404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptiopnFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}