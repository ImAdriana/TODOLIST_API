using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TODOLIST_API.Context;
using TODOLIST_API.DTO;
using TODOLIST_API.Mapping;
using TODOLIST_API.Service;
using TODOLIST_API.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Services
builder.Services.AddScoped<ITodoService, TodoService>();

//Validator
builder.Services.AddScoped<IValidator<TodoInsertDto>, TodoInsertValidator>();
builder.Services.AddScoped<IValidator<TodoUpdateDto>, TodoUpdateValidator>();


//Mappers
builder.Services.AddAutoMapper(typeof(UserProfile));

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
