using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Coupons
    {

        [Key]
        public int CouponId { get; set; }
        public string CouponName { get; set; }
        public string CouponDescription { get; set; }
        public double Discount { get; set; }
    }
}
