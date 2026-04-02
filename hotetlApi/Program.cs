using Microsoft.AspNetCore.Mvc;
using HotelApi.Models;
using Microsoft.AspNetCore.Components.RenderTree;
using HotelApi.Services;

var builder = WebApplication.CreateBuilder(args);

var json = System.IO.File.ReadAllText("hotels.json");
var hotelData = System.Text.Json.JsonSerializer.Deserialize<HotelData>(json);

if (hotelData == null)
{
    throw new Exception("Failed to load hotel data from Task2.json");
}

builder.Services.AddSingleton(hotelData);

builder.Services.AddScoped<IHotelService>(sp=>
{    
    var hotels = sp.GetRequiredService<HotelData>().Hotels ?? new List<Hotel>();
    return new HotelService(hotels);
});

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
