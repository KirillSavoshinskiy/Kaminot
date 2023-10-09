using Microsoft.EntityFrameworkCore; 
using System.Reflection;
using System.Text.Json.Serialization;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Endpoints.GetAllPaymentSystems;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connStr);
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentSystemRepository, PaymentSystemRepository>();

var app = builder.Build();

await SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder.AllowAnyHeader()
             .AllowAnyMethod()
             .AllowCredentials()
             .WithOrigins("http://localhost:4200"));
}

app.UseHttpsRedirection(); 
app.UseAuthorization(); 
app.MapGetAllStudents(); 

app.Run();


async Task SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var scopedContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            await scopedContext.Database.MigrateAsync();
            await Seed.SeedInitialDataAsync(scopedContext);
        }
        catch
        {
            throw;
        }
    }
}