using AcoWeb.API.DbContexts;
using AcoWeb.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EmployeesContext>(options =>
{
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EmployeesAcoDb1;Trusted_Connection=True;");
    options.LogTo(Console.WriteLine);
    options.EnableSensitiveDataLogging(true);
});

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetService<EmployeesContext>();
        context.Database.EnsureDeleted();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
        logger.LogError(ex, "Error happens when migrating the database");
    }
}

app.Run();
