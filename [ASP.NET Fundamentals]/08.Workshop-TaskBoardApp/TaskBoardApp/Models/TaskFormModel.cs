using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoardApp.Models
{
	using static Data.DataConstatnts.Task;
	public class TaskFormModel
	{
		[Required]
		[StringLength(TaskMaxTitle, MinimumLength = TaskMinTitle)]
		public string Title { get; set; } = null!;
		[Required]
		[StringLength(TaskMaxDescription, MinimumLength = TaskMinDescription)]
		public string Description { get; set; } = null!;

		[Display(Name = "Board")]
        public int BoardId { get; set; }
		public ICollection<TaskBoardModel>? Boards { get; set; }
    }
}
