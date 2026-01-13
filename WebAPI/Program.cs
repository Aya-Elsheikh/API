using Application.RealEstate.Queries;
using Infrastructure;
using Infrastructure.External;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
//builder.Services.AddApplication();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(
    Assembly.GetExecutingAssembly(),
    typeof(GetConceptsHandler).Assembly
);

builder.Services.AddMediatR(
    Assembly.GetExecutingAssembly(),
    typeof(GetAveragePricePerSqFtQueryAPI).Assembly
);

builder.Services.AddMediatR(
    Assembly.GetExecutingAssembly(),
    typeof(AnalyzeLocationCommand).Assembly
);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<JsonReferenceDataLoader>();
builder.Services.AddHttpClient<OverpassClient>();

builder.Services.AddScoped<ICompetitionService, CompetitionService>();
builder.Services.AddScoped<IScoringService, ScoringService>();
builder.Services.AddHttpClient<GooglePlacesClient>();

var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jadwa API V1");
    c.RoutePrefix = "swagger"; 
});

app.UseAuthorization();
app.MapControllers();

app.Run();
