

using Microsoft.EntityFrameworkCore;
using ProductAPI.Data; // Asegúrate de ajustar el namespace a donde tengas AppDbContext

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios (Dependency Injection)
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Swagger para documentación (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
