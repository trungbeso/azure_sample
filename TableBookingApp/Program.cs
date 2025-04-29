using Microsoft.EntityFrameworkCore;
using TableBookingApp.Data;
using TableBookingApp.Service;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

//DI
// give one instance per each Http request
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

// give one instance every single time you inject / ask for instace
//builder.Services.AddTransient<IRestaurantService, RestaurantService>();

// for whole app just give only one instance, danger for common usecase
//builder.Services.AddSingleton<IRestaurantService, RestaurantService>();

builder.Services.AddDbContext<TableBookingAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbContext") ?? "")
.EnableSensitiveDataLogging() //not use in PROD, just for dev purpose
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
