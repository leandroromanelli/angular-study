using ChatService.Dtos;
using Newtonsoft.Json;
using OpenTokSDK;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatService.Entities;
public class Room : EntityBase
{
    public Room() : base()
    {
        UserRooms = new List<UserRoom>();
    }

    public Room(RoomCreationDto roomCreationDto) : base()
    {
        Name = roomCreationDto.RoomName;
        UserRooms = roomCreationDto.Users.Select(user => new UserRoom() { User = new User(user.Name), RoomId = Id, Role = user.Role }).ToList();
    }

    [JsonProperty("sessionId")]
    public string SessionId { get; set; }
    
    [JsonProperty("roomName")]
    public string Name { get; set; }

    [JsonIgnore]
    public List<UserRoom> UserRooms { get; set; }

    [NotMapped]
    [JsonProperty("users", ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
    public List<User> Users
    {
        get { return UserRooms.Any() ? UserRooms.Select(r => r.User.AddToken(r.Token, r.Role)).ToList() : null; }
    }

    [NotMapped]
    [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
    public string? Token { get { return UserRooms.Any() ? null : _token; } set { _token = value; } }
    private string? _token = null;

    [NotMapped]
    [JsonProperty("role", ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
    public Role? Role { get { return UserRooms.Any() ? null : _role; } private set { _role = value; } }
    private Role? _role = null;

    internal Room AddToken(string token, Role? role)
    {
        Token = token;
        Role = role;

        return this;
    }
}