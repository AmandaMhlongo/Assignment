using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc.ViewModels
{
    public class ReservationViewModel
    {
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public RoomType RoomType { get; set; } // should be enum
        public int NumOfNights { get; set; }
        public int NumOfGuests { get; set; }
        public string Price { get; set; }
    }

    public enum RoomType
    {
        None,Single,Doubles
    }
}