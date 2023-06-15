using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryDbContext _data;

        public BookController(LibraryDbContext context)
        {
            _data = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await _data.Books
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();

            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int Id)
        {
            var book = await _data.Books
                .Where(b => b.Id == Id)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return BadRequest();
            }

            var userWithBook = await _data.IdentityUsersBooks
                .Where(ub => ub.BookId == Id && ub.CollectorId == GetUserId())
                .FirstOrDefaultAsync();

            if (userWithBook != null)
            {
                return RedirectToAction("All");
            }

            IdentityUserBook userBook = new IdentityUserBook()
            {
                CollectorId = GetUserId(),
                Book = book,
            };

            await _data.IdentityUsersBooks.AddAsync(userBook);
            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            BookFormModel model = new BookFormModel()
            {
                Categories = GetCategories()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!GetCategories().Any(c => c.Id == bookModel.CategoryId))
            {
                ModelState.AddModelError(nameof(bookModel.CategoryId), "Category does not exists!");
                return View();
            }

            Book book = new Book()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                ImageUrl = bookModel.Url,
                Rating = decimal.Parse(bookModel.Rating),
                CategoryId = bookModel.CategoryId
            };

            await _data.Books.AddAsync(book);
            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        private ICollection<BookCategoryFormModel> GetCategories()
        {
            return _data.Categories
                .Select(b => new BookCategoryFormModel
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
