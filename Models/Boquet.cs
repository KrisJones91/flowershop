using System.ComponentModel.DataAnnotations;

namespace flowershop.Models
{
    public class Boquet
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public bool wrap { get; set; }

    }
}