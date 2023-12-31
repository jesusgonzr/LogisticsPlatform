using LogisticsPlatform.API;
using LogisticsPlatform.Infrastructure;
using LogisticsPlatform.Infrastructure.PredefinedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<DataSeeder>();

// Load database context
builder.Services.AddDbContext<LogisticsPlatformContext>(
    opts => opts.UseInMemoryDatabase("LogisticsPlatformDB")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
    );

// Allow API for all sites.
builder.Services.AddCors(c =>
    {
        c.AddDefaultPolicy(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogisticsPlatform.API", Version = "v1" });

    // Enabled swagger anotation
    c.EnableAnnotations();
});

// Add dependency injection
builder.Services.AddApplication();

// Add singnalR
builder.Services.AddSignalR();

var app = builder.Build();

SeedData(app);

static void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    if (scopedFactory != null)
    {
        using var scope = scopedFactory.CreateScope();
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service?.Seed();
    }
}

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Logistic Plaform Manager API V1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<LogisticsPlatform.Infrastructure.Hubs.NotificationHub>("/locationHub");
});

app.Run();
