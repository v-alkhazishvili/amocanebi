using System;

namespace ConsoleApp1
{
    public class Hotel
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public double Rating { get; set; }
        public int PricePerNight { get; set; }

        public override string ToString()
        {
            return $"Hotel: {Name}, Location: {Location}, Rating: {Rating}, Price per Night: ${PricePerNight}";
        }
    }
}
