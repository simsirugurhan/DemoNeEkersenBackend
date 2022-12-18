using DemoNeEkersen.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//mediatR
builder.Services.AddMediatR(typeof(Program));
//postgreSql
builder.Services.AddDbContext<PostgreSqlDemoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("NeEkersenDemoDbConnection"), b => b.MigrationsAssembly("DemoNeEkersen.Data")));
builder.Services.AddScoped<DbContext>(provider => provider.GetService<PostgreSqlDemoDbContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();