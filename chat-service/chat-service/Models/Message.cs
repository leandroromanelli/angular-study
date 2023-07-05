using Newtonsoft.Json;

namespace chat_service.Models
{
    public class Message
    {
        public Message(string userName, string messageText)
        {
            UserName = userName;
            MessageText = messageText;
        }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("messageText")]
        public string MessageText { get; set; }
    }
}