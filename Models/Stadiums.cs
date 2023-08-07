using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Stadiums
    {
        [Key]
        public int StadiumId { get; set; }

        public string StadiumName { get; set; }

        public string Location { get; set; }


        public ICollection<Sports> Sports { get; set; }
    }
}
