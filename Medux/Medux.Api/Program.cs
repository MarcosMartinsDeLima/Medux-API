using DotNetEnv;
using Medux.Application;
using Medux.Infra;

var builder = WebApplication.CreateBuilder(args);


Env.Load();

string username = Environment.GetEnvironmentVariable("MONGO_INITDB_ROOT_USERNAME") ?? "default_user";
string password = Environment.GetEnvironmentVariable("MONGO_INITDB_ROOT_PASSWORD") ?? "default_pass";
string database = Environment.GetEnvironmentVariable("MONGO_INITDB_DATABASE") ?? "default_db";
string host = "mongodb";
string port = Environment.GetEnvironmentVariable("MONGO_PORT") ?? "27017";

string connectionString = $"mongodb://admin:senha@mongodb:27017/?authSource=admin";
Console.WriteLine($"MongoDB Connection String: {connectionString}");

builder.Services.ConfigurePersistance(connectionString, database);
builder.Services.ConfigureApplication();

builder.Services.AddControllers();

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
