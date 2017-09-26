using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }

        [DisplayName("RoomName")]
        public string RoomName { get; set; }

        [DisplayName("Room Type")]
        public string RoomType { get; set; }

        [DisplayName("Rate Per Day")]
        public double RatePerDay { get; set; }

        [DisplayName("Room Status")]
        public string RoomStatus { get; set; }

        [DisplayName("Number Of Beds")]
        public int NumberOfBeds { get; set; }
    }
}