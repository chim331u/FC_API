using System.Reflection;
using fc_minimalApi.Endpoints;
using fc_minimalApi.Extensions;
using fc_minimalApi.Services;
using Hangfire;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.AddApplicationServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSignalR();

builder.Services.AddHangfire(config =>
{
    config.
        UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseInMemoryStorage();
});
builder.Services.AddHangfireServer(options => options.SchedulePollingInterval = TimeSpan.FromSeconds(1));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "Minimal API", Version = "v1", Description = "File categorization API" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader()
            //.AllowCredentials()
            ;
    });
});

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


var app = builder.Build();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHub<NotificationHub>("notifications");

app.MapGroup("/api/v1/")
    .WithTags(" Files Detail endpoints")
    .MapFilesDetailEndPoint();

app.MapGroup("/api/v1/")
    .WithTags(" Configs endpoints")
    .MapConfigsEndPoint();

app.MapGroup("/api/v1/")
    .WithTags(" Actions endpoints")
    .MapActionsEndPoint();

app.Run();