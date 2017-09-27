using System.Data.Entity;

namespace WebMvc.Models
{
    public class FlicksHotelDbase : DbContext
    {
        public FlicksHotelDbase() : base("FlicksHotelDatabase")
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}