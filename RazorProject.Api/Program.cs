using Microsoft.EntityFrameworkCore;
using RazorProject.Api.Data;
using RazorProject.Api.Repositories;
using RazorProject.Api.Repositories.Interfaces;
using RazorProject.Api.Services;
using RazorProject.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IChamadoService, ChamadoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEnd", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("FrontEnd");
app.MapControllers();

await SeedData.InitializeAsync(app.Services);

app.Run();
