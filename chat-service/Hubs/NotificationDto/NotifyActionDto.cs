namespace Examroom.SSV3.Microservices.SignalR.NotificationDto
{
    public class NotifyActionDto
    {
        public string RoomId { get; set; }
        public string Action { get; set; }
        public string Sender { get; set; }
        public DateTime NotificatedTime { get; set; }
        public object Data { get; set; }
    }
}
