namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using Microsoft.AspNetCore.Identity;

    public class EventParticipant
    {
        [Required]
        [ForeignKey(nameof(Helper))]
        public string HelperId { get; set; } = null!;
        public virtual IdentityUser Helper { get; set; } = null!;

        [Required]
        public int EventId { get; set; }
        public virtual Event Event { get; set; } = null!;
    }
}
