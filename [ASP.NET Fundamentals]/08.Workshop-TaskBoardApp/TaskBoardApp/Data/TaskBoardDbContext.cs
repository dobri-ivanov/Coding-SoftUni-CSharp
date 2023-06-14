using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data
{
    using Task = Models.Task;
    public class TaskBoardDbContext : IdentityDbContext<IdentityUser>
    {
        private Board OpenBoard { get; set; } = null!;
        private Board InProgressBoard { get; set; } = null!;
        private Board DoneBoard { get; set; } = null!;

        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);


            SeedBoards();
            builder.Entity<Board>()
                   .HasData(this.OpenBoard, this.InProgressBoard, this.DoneBoard);

            builder.Entity<Task>()
                   .HasData(
                        new Task
                        {
                            Id = 1,
                            Title = "Prepare for ASP.NET Fundamentals exam",
                            Description = "Learn to use ASP.NET Core Identity",
                            CreatedOn = DateTime.Now.AddMonths(-1),
                            OwnerId = "8ae1ad20-c002-472b-805b-0ea16c3182c0",
                            BoardId = this.OpenBoard.Id
                        },
                        new Task
                        {
                            Id = 2,
                            Title = "Improve EF Core skills",
                            Description = "Learn using EF Core and MS SQL Server Management Studio",
                            CreatedOn = DateTime.Now.AddMonths(-5),
                            OwnerId = "de47e008-9daf-4bd0-b539-8278e42f61ea",
                            BoardId = this.DoneBoard.Id,
                        },
                        new Task
                        {
                            Id = 3,
                            Title = "Improve ASP.NET Core skills",
                            Description = "Learn using ASP.NET Core Identity",
                            CreatedOn = DateTime.Now.AddDays(-10),
                            OwnerId = "8ae1ad20-c002-472b-805b-0ea16c3182c0",
                            BoardId = this.InProgressBoard.Id,
                        },
                        new Task
                        {
                            Id = 4,
                            Title = "Prepare for C# Fundamentals Exam",
                            Description = "Prepare by solving old Mid and Final exams",
                            CreatedOn = DateTime.Now.AddYears(-1),
                            OwnerId = "8ae1ad20-c002-472b-805b-0ea16c3182c0",
                            BoardId = this.DoneBoard.Id,
                        });

            base.OnModelCreating(builder);
        }

        private void SeedBoards()
        {
            this.OpenBoard = new Board
            {
                Id = 1,
                Name = "Open"
            };
            this.InProgressBoard = new Board
            {
                Id = 2,
                Name = "In Progress"
            };
            this.DoneBoard = new Board
            {
                Id = 3,
                Name = "Done"
            };
        }
    }
}
