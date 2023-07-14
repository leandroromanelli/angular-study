using Newtonsoft.Json;

namespace ChatService.Dtos
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
        
        [JsonProperty("users")]
        public List<UserRoomCreationDto> Users { get; set; }
    }
}
