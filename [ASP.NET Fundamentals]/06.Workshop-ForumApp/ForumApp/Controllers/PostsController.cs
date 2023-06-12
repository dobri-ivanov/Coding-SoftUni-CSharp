using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
	public class PostsController : Controller
	{
		private readonly ForumAppDbContext data;
        public PostsController(ForumAppDbContext data)
        {
			this.data = data;
        }
        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var posts =  await data.Posts
				.Select(p => new PostViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content
				})
				.ToListAsync();

			return View(posts);
		}

        [HttpGet]
        public async Task<IActionResult> Add()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Add(PostFormModel formModel)
        {
			if (ModelState.IsValid)
			{
                Post post = new Post()
                {
                    Title = formModel.Title,
                    Content = formModel.Content
                };

                await data.Posts.AddAsync(post);
                await data.SaveChangesAsync();
            }			

			return RedirectToAction("All", "Posts");
        }

        [HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var post = await data.Posts.FindAsync(id);

			PostFormModel formModel = new PostFormModel()
			{
				Title = post.Title,
				Content = post.Content
			};

			return View(formModel);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PostFormModel formModel)
		{
			var post = await data.Posts.FindAsync(id);

			post.Title = formModel.Title;
			post.Content = formModel.Content;

			await data.SaveChangesAsync();

			return RedirectToAction("All");
		}

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await data.Posts.FindAsync(id);

            data.Posts.Remove(post);
			await data.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}
