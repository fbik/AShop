using AShop.Data.Interfaces;
using AShop.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IAllCars, MocksCars>();
builder.Services.AddTransient<ICarsCategory, MockCategory>();
builder.Services.AddMvc((option => option.EnableEndpointRouting = false));

//builder.Services.AddRazorPages().AddMvcOptions(options => options.EnableEndpointRouting = false);
//app.MapGet("/", () => "Hello World!");

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();


//app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run();