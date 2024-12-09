using Microsoft.EntityFrameworkCore;
using RoomRadar_Backend;
using RoomRadar_Backend.Repository;
using RoomRadar_Backend.Repository.Interfaces;
using RoomRadar_Backend.Services.Interfaces;
using RoomRadar_Backend.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BackendDbContext>(
    db => db.UseSqlServer(builder.Configuration.GetConnectionString("BackendDbConnectionString")), ServiceLifetime.Scoped
);

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SpecificOrigins"); //for cors

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
