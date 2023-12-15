using Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler__(this IApplicationBuilder app)
        {
            _ = app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error(contextFeature.Error, "Error Occured");
                        await context.Response.WriteAsync(new ResponseModel
                        {
                            IsSuccessful = false,
                            Message = "An error occured. Please contact the administrator for a resolution"
                        }.ToString());
                    }
                });
            });
        }
    }
}
