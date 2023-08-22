using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoleDto
    {
        public RoleDto(int value, string name)
        {
            Value = value;
            Name = name;
        }

        [JsonProperty("value")]
        public int Value { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
