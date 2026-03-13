using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Repository;
using EmployeeManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ================= SERVICES =================

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Sql"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);


// Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// JWT Service
builder.Services.AddScoped<JwtService>();

// JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["JwtKey"]))
        };
    });

builder.Services.AddAuthorization();

// ================= APP =================

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔐 Order matters!
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
