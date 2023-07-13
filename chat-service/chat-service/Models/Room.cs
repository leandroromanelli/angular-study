using Newtonsoft.Json;
using OpenTokSDK;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatService.Models;
public class Room : BaseModel
{
    public Room() : base()
    {
        UserRooms = new List<UserRoom>();
    }

    public Room(RoomCreationDto roomCreationDto) : base()
    {
        RoomName = roomCreationDto.RoomName;
        UserRooms = roomCreationDto.Users.Select(user => new UserRoom() { User = new User(user.Name), RoomId = Id, Role = (Role)user.Role }).ToList();
    }

    [JsonProperty("sessionId")]
    public string SessionId { get; set; }
    
    [JsonProperty("roomName")]
    public string RoomName { get; set; }


    [JsonIgnore]
    public List<UserRoom> UserRooms { get; set; }


    [NotMapped]
    [JsonProperty("users", ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<User> Users
    {
        get { return UserRooms.Select(r => r.User.AddToken(r.Token, r.Role)).ToList(); }
    }
}