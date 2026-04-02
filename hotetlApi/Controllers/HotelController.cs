using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        // [HttpGet("all")]
        // public IActionResult GetAll()
        // {
        //     _hotelService.PrintHotels();
        //     return Ok(_hotelService.FindHotelsByName("")); // Returns all hotels
        // }

        [HttpGet("searchByName")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var hotels = _hotelService.FindHotelsByName(name);
            return Ok(hotels);
        }

        [HttpGet("searchByLocation")]
        public IActionResult SearchByLocation([FromQuery] string location)
        {
            var hotels = _hotelService.FindHotelsByLocation(location);
            return Ok(hotels);
        }
    }
}
