using Examroom.SSV3.Microservices.SignalR.NotificationDto;
using Microsoft.AspNetCore.SignalR;

namespace Examroom.SSV3.Microservices.SignalR
{
    public class NotifyHub : Hub
    {
        public void GroupNotification(string group, string notification, NotifyActionDto content)
        {
            Clients.OthersInGroup(group).SendAsync(notification, content);
        }

        public void ClientNotification(string client, string notification, NotifyActionDto content)
        {
            Clients.Client(client).SendAsync(notification, content);
        }

        public void JoinGroup(string group, string user, string role)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public void LeaveGroup(string group, string user, string role)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }
    }
}
