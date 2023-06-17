namespace Homies.Models.Event
{
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.DataConstants.Event;
    public class EventFormModel
    {
        public EventFormModel()
        {
            this.Types = new HashSet<EventTypesFormModel>();
        }
        [Required]
        [StringLength(EventMaxName, MinimumLength = EventMinName)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventMaxDescription, MinimumLength = EventMinDescription)]
        public string Description { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }
        public ICollection<EventTypesFormModel> Types { get; set; } = null!;
    }
}
