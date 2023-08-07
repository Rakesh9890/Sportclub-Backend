using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string SportName { get; set; }
        public string SlotTime { get; set; }
        public string CourtName { get; set; }
        public double Price { get; set; }
        public string CourtImageurl { get; set; }
        public int UserId { get; set; }
    }
}