using System.ComponentModel.DataAnnotations;

namespace vacay.Models
{
    public class Rental : Trip
    {
        // public int Id { get; set; }
        [Required]
        public string car { get; set; }
        // public string description { get; set; }
        public int duration { get; set; }

        public float miles { get; set; }

        // public float price { get; set; }
    }
}