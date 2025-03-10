﻿using Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();

 builder.Services.AddInfrastructureServices(builder.Configuration);


// Configure the HTTP request pipeline.

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
