
using Microsoft.EntityFrameworkCore;
using Serilog;
using SportClubProject.Repository;
using SportClubProject.Services;
using SportClubProject.UserRepository;


var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute)
    .CreateLogger();
//use this line to override the built-in loggers
builder.Host.UseSerilog();
//use serilog along with built-in loggers
builder.Logging.AddSerilog();

// Add services to the container.
builder.Services.AddDbContext<SportsDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<ISportsRepo, SportsRepoImpl>();
builder.Services.AddScoped<ISlotsRepo, SlotsRepoImpl>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepoImpl>();
builder.Services.AddScoped<ICourtsRepo, CourtsRepoImplcs>();
builder.Services.AddScoped<ICouponsRepo, CouponsRepoImpl>();
builder.Services.AddScoped<ICartsRepo, CartsRepoImpl>();
builder.Services.AddScoped<IBookingRepo, BookingRepompl>();

//cross origin policy

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



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

app.UseAuthorization();
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
