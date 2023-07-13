using Newtonsoft.Json;
using OpenTokSDK;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatService.Models
{
    public class User : BaseModel
    {
        public User() : base()
        {
            UserRooms = new List<UserRoom>();
        }

        public User(string name) : base()
        {
            UserRooms = new List<UserRoom>();
            Name = name;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<UserRoom> UserRooms { get; set; }

        [NotMapped]
        [JsonProperty("token")]
        public string Token { get; set; }


        [NotMapped]
        [JsonProperty("rooms", ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public List<Room> Rooms
        {
            get { return UserRooms.Select(r => r.Room).ToList(); }
        }

        [NotMapped]
        [JsonProperty("role", ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public Role Role { get; private set; }

        internal User AddToken(string token, Role role)
        {
            Token = token;
            Role = role;

            return this;
        }
    }
}
