using System.ComponentModel.DataAnnotations;

namespace vacay.Models
{
    public class Cruise : Trip
    {
        // public int Id { get; set; }
        // public string title { get; set; }
        // public string description { get; set; }
        [Required]
        public string start { get; set; }
        public string end { get; set; }

        public int length { get; set; }
        // public float price { get; set; }

    }
}