using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Reflection;

namespace Application.Common.Extensions
{
    public static class CQRSExtensions
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Logger.Error(contextFeature.Error, "An Error Occured");
                        await Log.CloseAndFlushAsync();
                        //Log.Error($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(ResponseModel.Failure("Unable to process action..")));
                    }
                });
            });
        }

    }
}
