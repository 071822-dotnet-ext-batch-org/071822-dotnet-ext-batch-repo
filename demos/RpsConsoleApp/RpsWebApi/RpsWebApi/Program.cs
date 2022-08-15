using BusinessLayer;
using Microsoft.Extensions.DependencyInjection;
using Models;

var builder = WebApplication.CreateBuilder(args);// this is provided by the runtime and is necessary for to be able to buid an api

// Add services to the container.

builder.Services.AddControllers();// adds controllers
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();// ??
builder.Services.AddSwaggerGen();// adds swagger integration
builder.Services.AddScoped<ILogger, MyCustomException>();
builder.Services.AddScoped<Exception,MyCustomException>();
builder.Services.AddScoped<GamePlay>();
//builder.Services.AddScoped<IGetStuff>(x => x.GetService<IGamePlay>());




var app = builder.Build();// builds/provides the app object that you will use to coinfigure the app.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())// if you're in dev mode, you get swagger automatically
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();// allows the runtoime to route http requests based on their format.

app.UseAuthorization();// uses some type of filter so that not jsut anyone can access the app

app.MapControllers();// an maps the controllers to that routing works

app.Run();// actually starts the app.
