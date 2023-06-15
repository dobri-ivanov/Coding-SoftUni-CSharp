namespace Library.Models.Book
{
    using System.ComponentModel.DataAnnotations;

    using static DataValidations.DataConstants.Book;
    public class BookFormModel
    {
        public BookFormModel()
        {
            this.Categories = new HashSet<BookCategoryFormModel>();
        }
        [Required]
        [StringLength(BookMaxTitle, MinimumLength = BookMinTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookMaxAuthor, MinimumLength = BookMinAuthor)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookMaxDescription, MinimumLength = BookMinDescription)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(BookMinRating, BookMaxRating)]
        public string Rating { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
        public ICollection<BookCategoryFormModel> Categories { get; set; } = null!;
    }
}
