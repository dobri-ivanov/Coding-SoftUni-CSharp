namespace Homies.Models.Event
{
    public class EventDetailsViewModel : EventViewModel
    {
        public string Description { get; set; } = null!;

        public string End { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;
    }
}
