using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //read json file in the same directory as the executable
            var json = System.IO.File.ReadAllText("Task2.json");

            //line by line read the json file and store it in a array of strings
            var lines = json.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
            .Select(line => line.Trim())
            .ToList();          

            var hotel = new List<Dictionary<string, object>>();     

            for(int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("{") && lines[i + 1].Contains("Name"))
                {
                    var hotelInfo = new Dictionary<string, object>();
                    hotelInfo["Name"] = lines[i+1].Split(new[] {':'}, 2)[1].Trim().Trim('"', ',');
                    hotelInfo["Location"] = lines[i + 2].Split(':')[1].Trim().Trim('"', ',');
                    hotelInfo["Rating"] = double.Parse(lines[i + 3].Split(':')[1].Trim().Trim('"', ','));
                    hotelInfo["PricePerNight"] = int.Parse(lines[i + 4].Split(':')[1].Trim().Trim('"', ','));
                    hotel.Add(hotelInfo);
                }
            }   
            while (true)
            {
                Console.Write(">");
                var input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }
                else if(input.Split(' ')[0].ToLower() == "findbyname")
                {
                foreach(var hotelInfo in hotel)
                {
                    if(hotelInfo["Name"].ToString().ToLower().StartsWith(input.Split(' ')[1].ToLower()))
                    {
                        Console.WriteLine($"Hotel Name: {hotelInfo["Name"]}, Location: {hotelInfo["Location"]}, Rating: {hotelInfo["Rating"]}, Price Per Night: {hotelInfo["PricePerNight"]}");
                    }
                }                       
                }     
                else if(input.Split(' ')[0].ToLower() == "findbyloc")
                {
                foreach(var hotelInfo in hotel)
                {
                    if(hotelInfo["Location"].ToString().ToLower() == input.Split(' ')[1].ToLower())
                    {
                        Console.WriteLine($"Hotel Name: {hotelInfo["Name"]}, Location: {hotelInfo["Location"]}, Rating: {hotelInfo["Rating"]}, Price Per Night: {hotelInfo["PricePerNight"]}");
                    }
                }                      
                }                
            }
        }
    }
}
