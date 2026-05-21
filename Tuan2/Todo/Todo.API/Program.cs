using Microsoft.EntityFrameworkCore;
using Todo.Application.Modules;
using Todo.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("cnnStr")
    );
});
builder.Services.AddControllers();
builder.Services.AddApplicationModules();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();