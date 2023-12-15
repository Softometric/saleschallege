using Application.Common.Extensions;
using Infrastructure.DependencyManager;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


builder.Services.AddSpecialServices(config);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthenticationPlatform(config);
builder.Services.AddSwagger();

builder.Services.AddControllers().AddNewtonsoftJson()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });
var app = builder.Build();
app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());


app.Run();
