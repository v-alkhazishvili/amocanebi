using Microsoft.AspNetCore.Mvc;
using CalculatorApi.Models;
using CalculatorApi.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/",  (string text)  => //localhost:5130/?text=2+(5*2)
{
    if (string.IsNullOrWhiteSpace(text))
    {
        return Results.BadRequest("Please send a non-empty string.");
    }
    var calculatorService = new CalculatorService();
    var result = calculatorService.Evaluate(text);    
        
    return Results.Ok(new CalculationResult
    {
        Result = result
    });
});                    
app.Run();
