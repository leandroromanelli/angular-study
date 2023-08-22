using System.ComponentModel.DataAnnotations;

namespace MeetingService.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string Tenant { get; set; }
    }
}
