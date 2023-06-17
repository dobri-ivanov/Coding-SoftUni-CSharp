namespace Homies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models.Event;

    public class EventController : BaseController
    {
        public EventController(HomiesDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events = await _data.Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(dateTimeFormat),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventFormModel model = new EventFormModel()
            {
                Types = GetEventTypes()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            if (!GetEventTypes().Any(b => b.Id == eventModel.TypeId))
            {
                this.ModelState.AddModelError(nameof(eventModel.TypeId), "Type does not exist.");
                eventModel.Types = GetEventTypes();
                return View(eventModel);
            }

            Event currentEvent = new Event()
            {
                Name = eventModel.Name,
                Description = eventModel.Description,
                OrganiserId = GetUserId(),
                CreatedOn = DateTime.UtcNow,
                Start = DateTime.Parse(eventModel.Start),
                End = DateTime.Parse(eventModel.End),
                TypeId = eventModel.TypeId
            };

            await _data.Events.AddAsync(currentEvent);
            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var currEvent = await _data.Events
                .Where(e => e.Id == Id)
                .FirstOrDefaultAsync();

            if (currEvent == null)
            {
                return RedirectToAction("All");
            }

            if (currEvent.OrganiserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            EventFormModel model = new EventFormModel()
            {
                Name = currEvent.Name,
                Description = currEvent.Description,
                Start = currEvent.Start.ToString(dateTimeFormat),
                End = currEvent.End.ToString(dateTimeFormat),
                TypeId = currEvent.TypeId,
                Types = GetEventTypes()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            if (!GetEventTypes().Any(b => b.Id == eventModel.TypeId))
            {
                this.ModelState.AddModelError(nameof(eventModel.TypeId), "Type does not exist.");
                eventModel.Types = GetEventTypes();
                return View(eventModel);
            }

            var currEvent = await _data.Events
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (currEvent == null)
            {
                return RedirectToAction("All");
            }

            if (currEvent.OrganiserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            currEvent.Name = eventModel.Name;
            currEvent.Description = eventModel.Description;
            currEvent.Start = DateTime.Parse(eventModel.Start);
            currEvent.End = DateTime.Parse(eventModel.End);
            currEvent.TypeId = eventModel.TypeId;

            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Join(int Id)
        {
            var currEvent = await _data.Events
                .Where(b => b.Id == Id)
                .FirstOrDefaultAsync();

            if (currEvent == null)
            {
                return RedirectToAction("All");
            }

            var eventsWithParticipants = await _data.EventsParticipants
                .Where(ep => ep.EventId == Id && ep.HelperId == GetUserId())
                .FirstOrDefaultAsync();

            if (eventsWithParticipants != null)
            {
                return RedirectToAction("All");
            }

            EventParticipant eventsParticipants = new EventParticipant()
            {
                HelperId = GetUserId(),
                EventId = Id
            };

            await _data.EventsParticipants.AddAsync(eventsParticipants);
            await _data.SaveChangesAsync();

            return RedirectToAction("Joined");
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int Id)
        {
            var currEvent = await _data.Events
                .Where(b => b.Id == Id)
                .FirstOrDefaultAsync();

            if (currEvent == null)
            {
                return RedirectToAction("Joined");
            }

            var eventsWithParticipants = await _data.EventsParticipants
                .Where(ep => ep.EventId == Id && ep.HelperId == GetUserId())
                .FirstOrDefaultAsync();

            if (eventsWithParticipants == null)
            {
                return RedirectToAction("Joined");
            }

            _data.EventsParticipants.Remove(eventsWithParticipants);
            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var events = await _data.EventsParticipants
                .Where(ep => ep.HelperId == GetUserId())
                .Select(ep => new EventViewModel()
                {
                    Id = ep.EventId,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(dateTimeFormat),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName
                })
                .ToListAsync();

            return View(events);
        }

        //Bonus task
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var currEvent = await _data.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            if (currEvent == null)
            {
                return RedirectToAction("All");
            }

            var organizer = await _data.Users
                .FirstOrDefaultAsync(u => u.Id == currEvent.OrganiserId);

            var type = await _data.Types
                .FirstOrDefaultAsync(t => t.Id == currEvent.TypeId);


            if (organizer == null || type == null)
            {
                return RedirectToAction("All");
            }

            EventDetailsViewModel eventDetailsViewModel = new EventDetailsViewModel()
            {
                Id = currEvent.Id,
                Name = currEvent.Name,
                Description = currEvent.Description,
                Start = currEvent.Start.ToString(dateTimeFormat),
                End = currEvent.End.ToString(dateTimeFormat),
                Organiser = currEvent.Organiser.UserName,
                CreatedOn = currEvent.CreatedOn.ToString(dateTimeFormat),
                Type = type.Name
            };

            return View(eventDetailsViewModel);
        }
    }
}
