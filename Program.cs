using Microsoft.EntityFrameworkCore;
using PetPackApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=petpack.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// app.UseSwagger();
// app.UseSwaggerUI();
app.MapControllers();
app.Run();