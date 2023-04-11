using AircraftSpotter.Api;
using AircraftSpotter.Infrastructure;
using AircraftSpotter.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAircraftSightingService, AircraftSightingService>();
builder.Services.AddDbContext<AircraftSightingContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"), o => o.MigrationsAssembly("AircraftSpotter.Api"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

builder.Services.AddAutoMapper(typeof(AircraftSightingProfile));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
