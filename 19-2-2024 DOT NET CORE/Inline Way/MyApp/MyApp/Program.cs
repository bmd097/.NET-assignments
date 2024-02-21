using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Models;
using MyApp.Utils;
using System;
using System.Net;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new FishCatcherUtil()); // Dependency 

var app = builder.Build();

// Middlewares 
app.Use((context,next) => {
    Console.WriteLine($"In :: Context {context.Request.Method} ");
    var res = next(context);
    Console.WriteLine($"Out :: Context {context.Request.Method} ");
    return res;
});

app.Use((context, next) => {
    Console.WriteLine($"Next In :: Context {context.Request.Method} ");
    return next(context);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseAuthorization();
app.MapControllers();

List<Person> people = new List<Person>();
people.Add(new Person {
    Name = "Mohan",
    Age = 30,
    createdAt = DateTime.Now,
    Id = 1
});
people.Add(new Person {
    Name = "Kavya",
    Age = 30,
    createdAt = DateTime.Now,
    Id = 2
});

app.MapGet("/people/all", () => {
    return people;
});

app.MapPost("/people/add", (Person person) => {
    Console.WriteLine(person.ToString());
    return new {
        success=true
    };
});

app.MapGet("/test/{id}", (int id) => {
    Console.WriteLine($"In Method");
    return "B";
}).AddEndpointFilter((context, next) => {
    Console.WriteLine($"In");
    var res = next(context);
    Console.WriteLine($"Out");
    return res;
});

app.Run();
