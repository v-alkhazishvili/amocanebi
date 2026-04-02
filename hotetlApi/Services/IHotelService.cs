using HotelApi.Models;
using System.Collections.Generic;

namespace HotelApi.Services
{
    public interface IHotelService
    {
        void PrintHotels();
        List<Hotel> FindHotelsByName(string name);
        List<Hotel> FindHotelsByLocation(string location);
    }
}