using Microsoft.EntityFrameworkCore;
using SolarLabTask.DataBase;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;
using SolarLabTask.Repositories;
using SolarLabTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebAppContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IPersonListRepo, PersonListRepo>();
builder.Services.AddTransient<IPersonListService, PersonListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Web}/{action=Index}/{id?}");

app.Run();
