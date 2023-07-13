using Newtonsoft.Json;

namespace ChatService
{
    public class RoomCreationDto
    {
        public RoomCreationDto()
        {
        }

        public RoomCreationDto(string roomName)
        {
            RoomName = roomName;
        }


        [JsonProperty("roomName")]
        public string RoomName { get; set; }
        
        [JsonProperty("userNames")]
        public List<string> UserNames { get; set; }
    }
}
