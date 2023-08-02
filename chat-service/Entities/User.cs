using Newtonsoft.Json;
using OpenTokSDK;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatService.Entities
{
    public class User : EntityBase
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
        [JsonProperty("rooms", ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<Room> Rooms
        {
            get { return UserRooms.Any() ? UserRooms.Select(r => r.Room?.AddToken(r.Token, r.Role)).ToList() : null; }
        }

        [NotMapped]
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string? Token { get { return UserRooms.Any() ? null : _token; } set { _token = value; } }
        private string? _token = null;

        [NotMapped]
        [JsonProperty("role", ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Role? Role { get { return UserRooms.Any() ? null : _role; } private set { _role = value; } }
        private Role? _role = null;

        internal User AddToken(string token, Role? role)
        {
            Token = token;
            Role = role;

            return this;
        }
    }
}
