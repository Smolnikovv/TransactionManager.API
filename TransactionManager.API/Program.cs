using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransactionManager.API.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));

builder.Services.AddScoped<DatabaseChecker>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));




var app = builder.Build();
app.UseCors(options=>
    options
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader()
);

var scope = app.Services.CreateScope();
var databaseChecker = scope.ServiceProvider.GetService<DatabaseChecker>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
