using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Read json file in the same directory as the executable
            var json = System.IO.File.ReadAllText("Task2.json");

            // Deserialize the JSON into a root object
            var data = JsonSerializer.Deserialize<HotelData>(json);

            if (args.Length > 0)
            {
            var command = args[0].ToLower();
            var hotelName = args.Length > 1 ? args[1].ToLower() : string.Empty;
            if (command == "findbyname" && args.Length > 1)
            {
                var hotels = data?.FindHotelsByName(hotelName);
                if (hotels != null && hotels.Count > 0)
                {
                    foreach (var hotel in hotels)
                    {
                        Console.WriteLine(hotel);
                    }
                }
                else
                {
                    Console.WriteLine($"No hotels found with name starting with '{hotelName}'.");
                }    
            }
            else if (command == "findbyloc" && args.Length > 1)
                {
                    var hotels = data?.FindHotelsByLocation(hotelName);
                    if (hotels != null && hotels.Count > 0)
                    {
                        foreach (var hotel in hotels)
                        {
                            Console.WriteLine(hotel);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No hotels found in location '{hotelName}'.");
                    }
                }
            }
        }
    }
}
