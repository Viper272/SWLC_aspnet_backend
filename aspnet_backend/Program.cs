using aspnet_backend.Contexts;
using aspnet_backend.Endpoints;
using aspnet_backend.Game;
using aspnet_backend.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddCors(options =>
{
    //Allow CORS
    options.AddPolicy("AllowAnyOrigin", p => p
        .WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddSignalR();
//builder.Services.AddDbContext<PlayerDb>(opt => opt.UseInMemoryDatabase("PlayersList"));
builder.Services.AddSingleton<GameEngine>();

var app = builder.Build();
app.UseCors("AllowAnyOrigin");

app.UseDefaultFiles();
app.UseStaticFiles();


//Setup Server Endpoints
//Testing Endpoint
app.MapGet("/", () => "Hello World!");
//SignalR Endpoints
app.MapHub<GameHub>("/gamehub");
//REST Endpoints
//app.RegisterPlayerEndpoints();


//Start the web server
app.Run();
