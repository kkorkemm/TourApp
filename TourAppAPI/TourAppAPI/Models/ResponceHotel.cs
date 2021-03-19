using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourAppAPI.Entities;

namespace TourAppAPI.Models
{
    public class ResponceHotel
    {
        public ResponceHotel(Hotel hotel)
        {
            Id = hotel.ID;
            Name = hotel.HotelName;
            StarCount = hotel.StarCount;
            CountryName = hotel.Country.CountryName;
            HotelImage = hotel.HotelImage.ToList().FirstOrDefault()?.Image;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public int StarCount { get; set; }
        public string CountryName { get; set; }
        public byte[] HotelImage { get; set; }

    }
}