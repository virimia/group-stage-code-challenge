using CodeChallenge.WebApi.Data;
using CodeChallenge.WebApi.Infrastructure;
using CodeChallenge.WebApi.Infrastructure.Countries;
using CodeChallenge.WebApi.Infrastructure.GroupDraws;
using CodeChallenge.WebApi.Infrastructure.Groups;
using CodeChallenge.WebApi.Infrastructure.Services;
using CodeChallenge.WebApi.Infrastructure.Teams;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseInMemoryDatabase("InMemDb");
});

RegisterServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DatabasePreparation.PrePopulate(app);

app.Run();

void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IGroupService, GroupService>();
    builder.Services.AddTransient<IGroupDrawService, GroupDrawService>();
    builder.Services.AddTransient<ITeamsRepository, TeamsRepository>();
    builder.Services.AddTransient<ICountriesRepository, CountriesRepository>();
    builder.Services.AddTransient<IGroupRepository, GroupRepository>();
    builder.Services.AddTransient<IGroupDrawRepository, GroupDrawRepository>();
}
