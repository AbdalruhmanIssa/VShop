using System.ComponentModel.DataAnnotations;

namespace VShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Discount { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public string? Image { get; set; }
        [Range(0, 5)]
        public double Rate { get; set; }
        public int CategoryId {  get; set; }
        public Category Category { get; set; }

    }
}
