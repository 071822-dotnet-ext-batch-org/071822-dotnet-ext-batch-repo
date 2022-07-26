using BusinessLayer;
using RepositoryAccessLayer;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IReimbursementBusinessLayer, ReimbursementBusinessLayer>();
builder.Services.AddScoped<IReimbursementRepoLayer, ReimbursementRepoLayer>();
builder.Services.AddCors((options) =>
{
    options.AddPolicy(name: "allowAll", policy1 =>
    {
        policy1.WithOrigins("http://127.0.0.1:5500")
        .AllowAnyHeader()
        .AllowAnyMethod();
        //policy1.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var string1 = builder.Configuration["ConnectionStrings:ReimbursementApiDb"];


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
