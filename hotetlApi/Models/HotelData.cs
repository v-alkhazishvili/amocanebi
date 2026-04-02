using System;
using System.Runtime.Serialization;

namespace HotelApi.Models
{
    public class HotelData
    {
        public List<Hotel>? Hotels { get; set; } = new List<Hotel>();
    }
}
