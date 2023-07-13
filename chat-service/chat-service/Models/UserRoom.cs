using Newtonsoft.Json;

namespace ChatService.Models
{
    public class UserRoom :BaseModel
    {
        public UserRoom(Guid userId, Guid roomId, string token) : base()
        {
            UserId = userId;
            RoomId = roomId;
            Token = token;
        }

        public UserRoom() : base() 
        {
        }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public string Token { get; set; }
    }
}
