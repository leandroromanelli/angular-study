using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ChatService.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
