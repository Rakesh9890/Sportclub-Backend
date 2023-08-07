using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Sports
    {

        [Key]
        public int SportId { get; set; }
        public string SportName { get; set; }
        public string SportImageUrl { get; set; }
        public string Status { get; set; }

        public ICollection<Courts> Courts { get; set; }

    }
}