namespace TaskBoardApp.Models
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            this.Tasks = new HashSet<TaskViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<TaskViewModel> Tasks { get; set; }
    }
}
