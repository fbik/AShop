using AShop.Data.Interfaces;
using AShop.Data.Mocks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using AShop.Data;
using AShop.Data.Models;
using AShop.Data.Repository;
using FubuCore.Descriptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var hostEnv = builder.Environment;
var _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettingsOne.json")
    .Build();


builder.Services.AddTransient<IAllCars, MocksCars>();
builder.Services.AddTransient<ICarsCategory, MockCategory>(); 
//builder.Services.AddTransient<IAllOrders, OrdersRepository>();
//builder.Services.AddDbContext<AppDBContent>();
//builder.Services.AddMvc((option => option.EnableEndpointRouting = false));
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddTransient<IAllCars, CarRepository>();
//builder.Services.AddTransient<ICarsCategory, MockCategory>();
//builder.Services.AddTransient<IAllOrders, OrdersRepository>();
builder.Services.AddScoped(sp => AShopCart.GetCart(sp));

builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

//builder.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

//builder.Services.AddRazorPages().AddMvcOptions(options => options.EnableEndpointRouting = false);
//app.MapGet("/", () => "Hello World!");

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
//app.UseMvcWithDefaultRoute();
app.UseMvc(routes =>
{
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new {Controller="Car", action="List"});
});

void Configure(IApplicationBuilder app, IHostEnvironment env)
{
    using (var scope = app.ApplicationServices.CreateScope())
    {
        AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
        DBObjects.Initial(content);
    }
}

app.Run();

//app = builder.Build();

//app.MapGet("/", () => "Hello World!");

