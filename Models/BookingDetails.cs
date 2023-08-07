using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookingDetails
    {

        [Key]
        public int BookingId { get; set; }
        public string Bookingdate { get; set; }
        public string SportName { get; set; }
        public string SlotTime { get; set; }
        public string CourtName { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }
    }
}
