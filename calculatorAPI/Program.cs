using Microsoft.AspNetCore.Mvc;
using CalculatorApi.Models;
using CalculatorApi.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Simple endpoint that echoes back the string you send
app.MapGet("/",  ([FromBody] string text)  =>
{
    if (string.IsNullOrWhiteSpace(text))
    {
        return Results.BadRequest("Please send a non-empty string.");
    }
    var calculatorService = new CalculatorService();
    var result = calculatorService.Evaluate(text);    
    return Results.Ok(result);
});            
// Optional: GET endpoint to test if API is running
app.Run();
