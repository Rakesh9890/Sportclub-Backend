using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Slot
    {
        [Key]
        public int SlotId { get; set; }
        public string SlotTime { get; set; }
        public string Day { get ; set; }    

    }
}
