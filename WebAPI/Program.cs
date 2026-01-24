using Application.Comman.Constants;
using Application.Comman.Interfaces;
using Application.RealEstate.Queries;
using Infrastructure;
using Infrastructure.External;
using Infrastructure.Persistence;
using Infrastructure.Services;
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
    typeof(GetAveragePricePerSqFtQueryAPI).Assembly
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCrossOrigin", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(_ => true);
    });
});
var smtpSettings = new SmtpSettings
{
    Host = "smtp.gmail.com",
    Port = 587,
    Username = "jadwah2030@gmail.com",
    Password = "hpch twio vchs bnbp",
    EnableSsl = true,
    FromEmail = "jadwah2030@gmail.com",
    FromName = "Jadwah"
};

builder.Services.AddSingleton(smtpSettings);
builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<JsonReferenceDataLoader>();
builder.Services.AddHttpClient<OverpassClient>();

builder.Services.AddScoped<ICompetitionService, CompetitionService>();
builder.Services.AddScoped<IScoringService, ScoringService>();
builder.Services.AddHttpClient<GooglePlacesClient>();
builder.Services.AddScoped<IJwtService, JwtService>();

var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jadwa API V1");
    c.RoutePrefix = "swagger"; 
});
app.UseHttpsRedirection();

app.UseRouting();               
app.UseCors("AllowCrossOrigin");
app.UseAuthorization();
app.MapControllers();

app.Run();
