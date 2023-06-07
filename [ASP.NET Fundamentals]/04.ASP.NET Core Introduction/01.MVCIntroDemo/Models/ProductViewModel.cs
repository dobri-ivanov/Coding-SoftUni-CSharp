using System.ComponentModel.DataAnnotations;

namespace _01.MVCIntroDemo.Models
{
	public class ProductViewModel
	{
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public double Price { get; set; }
    }
}
