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

            while (true)
            {
                Console.Write(">");
                var input = Console.ReadLine();

                if (input?.ToLower() == "exit")
                {
                    break;
                }
                else if(input != "findbyname" && input?.Split(' ')[0].ToLower() == "findbyname")
                {
                foreach(var hotels in data.Hotels)
                {
                    if(hotels.Name?.ToLower().StartsWith(input.Split(' ')[1].ToLower()) == true)
                    {
                        Console.WriteLine(hotels.ToString());
                    }
                }                       
                }     
                else if(input != "findbyloc" && input?.Split(' ')[0].ToLower() == "findbyloc")
                {
                    foreach(var hotels in data.Hotels)
                    {
                        if(hotels.Location?.ToLower() == input.Split(' ')[1].ToLower())
                        {
                            Console.WriteLine(hotels.ToString());
                        }
                    }                      
                }
            }
        }
    }
}
