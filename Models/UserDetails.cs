using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserDetails
    {

        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public long UserMobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserAge { get; set; }
        public string Gender { get; set; }

        public string Role { get; set; }
    }
}
