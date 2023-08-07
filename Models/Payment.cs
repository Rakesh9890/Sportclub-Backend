using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
    {

        [Key]
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public string PaymentMode { get; set; }
        public string Status { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }
    }
}
