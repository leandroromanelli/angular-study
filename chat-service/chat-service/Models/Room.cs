namespace ChatService.Models;
public partial class Room
{
    public int RoomId { get; set; }
    public string SessionId { get; set; }
    public string RoomName { get; set; }
    public string Token { get; set; }
}