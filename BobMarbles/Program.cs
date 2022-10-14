using Microsoft.EntityFrameworkCore;
using BobMarbles.Models;
using BobMarbles.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository, Repository<AppMainContext>>();
builder.Services.AddDbContext<AppMainContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BobMarblesConnection")) );
builder.Services.AddCors();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(x => x
         .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials()
         //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
         .SetIsOriginAllowed(origin => true));// Allow any origin


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
