using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{
	using static DataValidations.DataConstants.Post;
	public class PostViewModel
	{
		public int Id { get; set; }
		[StringLength(TitleMaxLength, MinimumLength =TitleMinLength, ErrorMessage = "Title length is not correct!")]
		public string Title { get; set; } = null!;
		[StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = "Content length is not correct!")]
		public string Content { get; set; } = null!;
	}
}
