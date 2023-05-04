using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace chat_service
{
    public class Message 
    {
        public Message(string userName, string messageText)
        {
            UserName = userName;
            MessageText = messageText;
        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }
        
        [JsonProperty("messageText")]
        public string MessageText { get; set; }
    }
}