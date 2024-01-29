using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using MovieAPI.Models.Data.Repository;
using MovieAPI.Models.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMovie, MovieService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CiniMoviesContext>(
    o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("DBConn")
    )
);

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

app.Run();
