using System.ComponentModel.DataAnnotations;

namespace vacay.Models
{
    public class Cruise
    {
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; }

        public int length { get; set; }
        public float price { get; set; }

    }
}