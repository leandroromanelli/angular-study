using Newtonsoft.Json;
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

        internal User AddToken(string token)
        {
            Token = token;

            return this;
        }
    }
}
