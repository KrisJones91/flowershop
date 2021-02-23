using System.ComponentModel.DataAnnotations;

namespace flowershop.Models
{
    public class Flower
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public float price { get; set; }
    }
}