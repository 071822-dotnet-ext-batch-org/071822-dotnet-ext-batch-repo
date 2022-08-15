var builder = WebApplication.CreateBuilder(args);// this is provided by the runtime and is necessary for to be able to buid an api

// Add services to the container.

builder.Services.AddControllers();// adds controllers
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();// ??
builder.Services.AddSwaggerGen();// adds swagger integration

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
