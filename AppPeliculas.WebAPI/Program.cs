using AppPeliculas.Model.Services;
using AppPeliculas.ApplicationServices.Services;
using AppPeliculas.Model.Interfaces;
using AppPeliculas.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Relación entre las interfaces y sus implementaciones
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();


// Permitir solicitudes del frontend
builder.Services.AddCors(options => options.AddPolicy(name: "MoviesOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MoviesOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
