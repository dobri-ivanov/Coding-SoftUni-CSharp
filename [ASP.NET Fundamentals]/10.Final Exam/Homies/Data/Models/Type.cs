namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.DataConstants.Type;

    public class Type
    {
        public Type()
        {
            this.Events = new HashSet<Event>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeMaxName)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } = null!;
    }
}
