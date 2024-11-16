using aspnet_backend.Contexts;
using aspnet_backend.Endpoints;
using aspnet_backend.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", p => p
        .WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddSignalR();
builder.Services.AddDbContext<PlayerDb>(opt => opt.UseInMemoryDatabase("PlayersList"));

var app = builder.Build();
app.UseCors("AllowAnyOrigin");

app.UseDefaultFiles();
app.UseStaticFiles();


app.MapGet("/", () => "Hello World!");
//app.MapHub<ChatHub>("/hub");
app.RegisterPlayerEndpoints();


//Start the web server
app.Run();
