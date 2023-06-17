namespace Homies.Controllers
{
    using System.Security.Claims;
    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    
    using Data;
    using Models.Event;

    [Authorize]
    public class BaseController : Controller
    {
        private protected const string dateTimeFormat = "yyyy-MM-dd H:mm";
        private protected readonly HomiesDbContext _data;

        public BaseController(HomiesDbContext context)
        {
            _data = context;
        }

        private protected ICollection<EventTypesFormModel> GetEventTypes()
        {
            return _data.Types
                .Select(b => new EventTypesFormModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();
        }

        private protected string GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
