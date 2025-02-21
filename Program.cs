using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��es do pipeline de requisi��es
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();