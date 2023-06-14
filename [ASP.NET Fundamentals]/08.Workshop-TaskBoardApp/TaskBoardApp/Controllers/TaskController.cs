using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
	using Task = Data.Models.Task;
	[Authorize]
	public class TaskController : Controller
	{
		
		private readonly TaskBoardDbContext _data;
		public TaskController(TaskBoardDbContext data)
		{
			_data = data;
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			TaskFormModel taskModel = new TaskFormModel()
			{
				Boards = GetBoards()
			};

			return View(taskModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(TaskFormModel taskModel)
		{
			if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
			{
				ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
				return View();
			}

			if (!ModelState.IsValid)
			{
				taskModel.Boards = GetBoards();
				return View(taskModel);
			}

			Task task = new Task()
			{
				Title = taskModel.Title,
				Description = taskModel.Description,
				CreatedOn = DateTime.Now,
				BoardId = taskModel.BoardId,
				OwnerId = GetUserId()
			};

			await _data.Tasks.AddAsync(task);
			await _data.SaveChangesAsync();

			
			return RedirectToAction("All", "Boards");
		}

		private string GetUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}

		private ICollection<TaskBoardModel> GetBoards()
		{
			var boards = _data.Boards
				.Select(b => new TaskBoardModel()
				{
					Id = b.Id,
					Name = b.Name
				})
				.ToList();


			return boards;
		}
	}
}

