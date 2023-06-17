namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using Microsoft.AspNetCore.Identity;

    using static DataValidation.DataConstants.Event;
    public class Event
    {
        public Event()
        {
           this.EventsParticipants = new HashSet<EventParticipant>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventMaxName)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EventMaxDescription)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Organiser))]
        public string OrganiserId { get; set; } = null!;
        [Required]
        public virtual IdentityUser Organiser { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        [Required]
        public virtual Type Type { get; set; } = null!;

        public virtual ICollection<EventParticipant> EventsParticipants { get; set; } = null!;

    }
}
