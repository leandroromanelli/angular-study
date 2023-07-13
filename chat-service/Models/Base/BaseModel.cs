using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ChatService.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
