using System.ComponentModel.DataAnnotations;

namespace flowershop.Models
{
    public class Flower
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public float price { get; set; }
    }
}