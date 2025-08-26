using CampusEventAggregator.Data;
using Microsoft.EntityFrameworkCore;

using CampusEventAggregator.Models;

var builder = WebApplication.CreateBuilder(args);

// Load connection string from appsettings.json
var ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(ConnectionStrings, ServerVersion.AutoDetect(ConnectionStrings)));

// Enable CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Force app to listen on port 5000
builder.WebHost.UseUrls("http://*:5000");

var app = builder.Build();

// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
