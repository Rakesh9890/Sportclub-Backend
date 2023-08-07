using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courts
    {


        [Key]
        public int CourtId { get; set; }
        public string CourtName { get; set; }
        
        public string category { get; set; }
        public string CourtImageUrl { get; set; }
        public double CourtPrice { get; set; }

        public string Status { get; set; }
    }
}
