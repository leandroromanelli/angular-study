using Newtonsoft.Json;

namespace ChatService.Models
{
    public class Message : BaseModel
    {
        public Message() : base()
        {
        }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("messageText")]
        public string MessageText { get; set; }

        [JsonProperty("roomId")]
        public Guid RoomId { get; set; }
    }
}