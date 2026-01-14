using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
try
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
    });

    Console.WriteLine("✅ Database context configured successfully");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error configuring database: {ex.Message}");
    throw;
}

builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Corporate HR System API",
        Version = "v1",
        Description = "API для управления корпоративной HR системой"
    });
});

var app = builder.Build();

// Проверка подключения к базе данных при запуске
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var canConnect = await dbContext.Database.CanConnectAsync();

        if (canConnect)
        {
            Console.WriteLine("✅ Successfully connected to the database!");

            // Проверяем существование таблиц (опционально)
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                Console.WriteLine($"⚠️  Found {pendingMigrations.Count()} pending migrations:");
                foreach (var migration in pendingMigrations)
                {
                    Console.WriteLine($"   - {migration}");
                }
            }
            else
            {
                Console.WriteLine("✅ Database is up to date with migrations");
            }
        }
        else
        {
            Console.WriteLine("❌ Cannot connect to the database!");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Database connection error: {ex.Message}");

        // Выводим детальную информацию об ошибке
        if (ex.InnerException != null)
        {
            Console.WriteLine($"   Inner exception: {ex.InnerException.Message}");
        }
    }
}

// Configure the HTTP request pipeline.
// ВКЛЮЧАЕМ SWAGGER В ЛЮБОЙ СРЕДЕ (Development/Production)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Corporate HR API v1");
    c.RoutePrefix = "swagger"; // Доступ по адресу /swagger
    c.DisplayRequestDuration(); // Показывать время выполнения запроса
    c.EnableDeepLinking(); // Включить глубокие ссылки
    c.EnableValidator(); // Включить валидатор
});

// Если не в режиме разработки, показываем предупреждение
if (!app.Environment.IsDevelopment())
{
    Console.WriteLine("⚠️  WARNING: Running in non-development environment with Swagger enabled!");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Добавляем маршрут для корневого URL, который перенаправляет на Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

Console.WriteLine($"🚀 Application starting at: {DateTime.Now}");
Console.WriteLine($"🌐 Swagger UI available at: https://localhost:5001/swagger");
Console.WriteLine($"📚 API documentation at: https://localhost:5001/swagger/v1/swagger.json");

app.Run();