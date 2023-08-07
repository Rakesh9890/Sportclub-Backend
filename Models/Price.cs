using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }
        public Double SportPrice { get; set; }
       
    }
}
