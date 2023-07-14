using OpenTokSDK;

namespace ChatService.Entities
{
    public class UserRoom :EntityBase
    {
        public UserRoom(Guid userId, Guid roomId, string token, Role role) : base()
        {
            UserId = userId;
            RoomId = roomId;
            Token = token;
            Role = role;

            User = null;
            Room = null;
        }

        public UserRoom() : base() 
        {
        }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public Role Role { get; set; }
        public string Token { get; set; }
    }
}
