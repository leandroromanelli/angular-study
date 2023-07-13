using Newtonsoft.Json;
using OpenTokSDK;

namespace ChatService
{
    public class UserRoomCreationDto
    {
        public UserRoomCreationDto()
        {
        }

        public UserRoomCreationDto(string name, Role role)
        {
            Name = name;
            Role = role;
        }


        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("role")]
        public Role Role { get; set; }
    }
}
