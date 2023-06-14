using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
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
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();
            Task task = new()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId,
                CreatedOn = DateTime.Now
            };

            await _data.Tasks.AddAsync(task);
            await _data.SaveChangesAsync();

            var boards = this._data.Boards;
            return RedirectToAction("All", "Boards");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await _data
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();
            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel model = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };
            
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            if (task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }
            TaskViewModel model = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description             
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel viewModel)
        {
			var task = await _data.Tasks.FindAsync(viewModel.Id);

			if (task == null)
			{
				return BadRequest();
			}

			if (task.OwnerId != GetUserId())
			{
				return Unauthorized();
			}

            _data.Tasks.Remove(task);
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
		}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();
            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exists!");
            }

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();
                
                return View(taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Boards");

        }
        private ICollection<TaskBoardModel> GetBoards()
        {
            return _data.Boards
                .Select(b => new TaskBoardModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();
        }

        private string GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

