using Microsoft.EntityFrameworkCore;
using CodetestBF.WebApi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


// Add DbContext and repo to the DI container
builder.Services.AddDbContext<CodetestBFDb>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));
//builder.Services.AddTransient<CodetestBFDb, CodetestBFDb>();
builder.Services.AddTransient<IDataRepository, DataRepository>();

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
