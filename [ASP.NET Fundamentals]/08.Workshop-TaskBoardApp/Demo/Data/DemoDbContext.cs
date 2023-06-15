using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
	public class DemoDbContext : IdentityDbContext
	{
		public DemoDbContext(DbContextOptions<DemoDbContext> options)
			: base(options)
		{
		}
	}
}