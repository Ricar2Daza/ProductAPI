

using Microsoft.EntityFrameworkCore;
using ProductAPI.Data; // Aseg�rate de ajustar el namespace a donde tengas AppDbContext

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios (Dependency Injection)
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Swagger para documentaci�n (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuraci�n de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
