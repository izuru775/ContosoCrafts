using System.Text.Json;
using ContosCrafts.Website.Models;
using ContosCrafts.Website.Services;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<JsonFileProductService>();
builder.Services.AddControllers();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
//app.MapGet("/products", (context) =>
//{
//    var products = app.Services.GetService<JsonFileProductService>().GetProducts();
//    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
//    return context.Response.WriteAsync(json);

//});
app.MapControllers();
app.MapBlazorHub();

app.Run();

