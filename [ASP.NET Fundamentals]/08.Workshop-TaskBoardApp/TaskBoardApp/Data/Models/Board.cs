
namespace TaskBoardApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstatnts.Board;
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardMaxName)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
