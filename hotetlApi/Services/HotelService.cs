using System;
using System.Runtime.Serialization;
using HotelApi.Models;

namespace HotelApi.Services
{
    public class HotelService : IHotelService
    { 
        private readonly List<Hotel> _hotels;
        
        public HotelService(List<Hotel> hotels)
        {
            _hotels = hotels ?? throw new ArgumentNullException(nameof(hotels));
        }
        public void PrintHotels()
        {
            foreach (var hotel in _hotels)
            {
                Console.WriteLine(hotel.Name);
            }            
        }
        public List<Hotel> FindHotelsByName(string name)
        {
            var result = new List<Hotel>();

            foreach (var hotel in _hotels)
            {
                if (!string.IsNullOrEmpty(hotel.Name) && hotel.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(hotel);
                }
            }            
            return result; 
           }
        public List<Hotel> FindHotelsByLocation(string location)
        {
            var result = new List<Hotel>();
            foreach (var hotel in _hotels)
            {
                if (!string.IsNullOrEmpty(hotel.Location) && hotel.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(hotel);
                }
            }
            return result;
        }
    }
}
