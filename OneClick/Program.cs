using Microsoft.EntityFrameworkCore;
using OneClick.Infrastructure.Db;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Repository;
using OneClick.Models;
using OneClick.Service;
using OneClick.Service.Interface;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddDbContext<MyDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<OneClickContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddLogging();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
//builder.Services.AddScoped<EmailAddress>

//builder.Services.AddDbContext<MyDbContext>(options=>options)

//builder.Services.Configure<MyAppSettings>(Config.Configuration.GetSection("AppSettings"));
var app = builder.Build();





// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
