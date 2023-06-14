namespace TaskBoardApp.Models
{
	public class HomeViewModel
	{
        public HomeViewModel()
        {
                this.BoardsWithTasksCount = new HashSet<HomeBoardModel>();
        }
        public int AllTasksCount { get; init; }
		public ICollection<HomeBoardModel> BoardsWithTasksCount { get; init; } = null!;
        public int UserTasksCount { get; init; }
    }
}
