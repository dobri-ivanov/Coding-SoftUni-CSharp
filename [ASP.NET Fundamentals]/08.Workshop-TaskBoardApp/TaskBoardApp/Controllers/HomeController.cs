using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private readonly TaskBoardDbContext _data;
		public HomeController(TaskBoardDbContext context)
		{
			_data = context;
		}

		public async Task<IActionResult> Index()
		{
			var taskBoards = await _data.Boards
				.Select(b => b.Name)
				.Distinct()
				.ToListAsync();

			var tasksCount = new List<HomeBoardModel>();

			foreach (var boardName in taskBoards)
			{
				var currentBoardTasksCount = _data.Tasks.Where(t => t.Board.Name == boardName).Count();

				tasksCount.Add(new HomeBoardModel()
				{
					BoardName = boardName,
					TasksCount = currentBoardTasksCount
				});
			}

			int userTasksCount = -1;

			if (User.Identity.IsAuthenticated)
			{
				var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
				userTasksCount = _data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
			}

			HomeViewModel model = new HomeViewModel()
			{
				AllTasksCount = _data.Tasks.Count(),
				BoardsWithTasksCount = tasksCount,
				UserTasksCount = userTasksCount
			};

			return View(model);
		}
	}
}