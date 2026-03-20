using System;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    public class HotelData
    {
        public List<Hotel>? Hotels { get; set; }        
        public void PrintHotels()
        {
            if (Hotels != null)
            {
                foreach (var hotel in Hotels)
                {
                    Console.WriteLine(hotel.Name);
                }
            }
        }
        public List<Hotel> FindHotelsByName(string name)
        {
            var result = new List<Hotel>();
            if (Hotels != null)
            {
                foreach (var hotel in Hotels)
                {
                    if (hotel.Name != null && hotel.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(hotel);
                    }
                }
            }
            return result; 
           }
        public List<Hotel> FindHotelsByLocation(string location)
        {
            var result = new List<Hotel>();
            if (Hotels != null)
            {
                foreach (var hotel in Hotels)
                {
                    if (hotel.Location != null && hotel.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(hotel);
                    }
                }
            }
            return result;
        }
    }
}