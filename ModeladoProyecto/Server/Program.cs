using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using ModeladoProyecto.BData.Data;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));
builder.Services.AddSwaggerGen(c =>
c.SwaggerDoc("v1", new OpenApiInfo { Title = "ModeladoProyecto", Version = "v1" })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModeladoProyecto v1"));
    app.UseWebAssemblyDebugging();
    }
else
    {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    }

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
