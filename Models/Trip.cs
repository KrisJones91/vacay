using System.ComponentModel.DataAnnotations;

namespace vacay.Models
{
    public class Trip
    {
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
    }
}