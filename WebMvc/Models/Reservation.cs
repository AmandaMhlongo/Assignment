using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;


namespace WebMvc.Models
{
    public class Reservation
    {
        [Key]
        public int BookingID { get; set; }

        [Required(ErrorMessage = "Please select your room")]
        public int RoomID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Date of Booking")]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Please select Your check in Date")]
        [DataType(DataType.Date)]
        [Display(Name = "check In Date")]
        public DateTime checkInDate { get; set; }

        [Required(ErrorMessage = "Please select Your check out Date")]
        [DataType(DataType.Date)]
        [Display(Name = "check  Out Date")]
        public DateTime checkOutDate { get; set; }

        public int numberOFGuests { get; set; }
        public Double Price { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("RoomID")]
        public virtual Room Room { get; set; }
    }
}