using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.Interface;
using QLBH.Service;
using QLBH.AutoMapper;
using QLBH.App_Start;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(Mapping));

//MAP SERVICE
AutoFac.Res(builder.Services, builder.Configuration);



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
