
namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataValidations.DataConstants.Book;

    public class Book
    {
        public Book()
        {
            this.UsersBooks = new HashSet<IdentityUserBook>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookMaxTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(BookMaxAuthor)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(BookMaxDescription)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<IdentityUserBook> UsersBooks { get; set; } = null!;


    }
}
