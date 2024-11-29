using GamesMarket.DataContext;
using GamesMarket.DataContext.Interfaces;
using GamesMarket.DataContext.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GamesMarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GamesMarketDb"));
});

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
