using Microsoft.EntityFrameworkCore;
using ItemsApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDb>(opt =>
    opt.UseSqlite("Data Source=items.db"));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
