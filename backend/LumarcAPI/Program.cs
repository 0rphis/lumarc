using LumarcAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LumarcContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LumarcContext>();

    try
    {
        context.Database.CanConnect();

        Console.WriteLine("✅ Conectado ao PostgreSQL!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Erro ao conectar: {ex.Message}");
    }
}

app.MapGet("/", () => "API Lumarc funcionando!");

app.MapControllers();

app.Run();
