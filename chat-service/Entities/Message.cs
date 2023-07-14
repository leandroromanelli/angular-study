using Newtonsoft.Json;

namespace ChatService.Entities
{
    public class Message : EntityBase
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