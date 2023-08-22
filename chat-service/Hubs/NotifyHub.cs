using Examroom.SSV3.Microservices.SignalR.NotificationDto;
using Microsoft.AspNetCore.SignalR;

namespace Examroom.SSV3.Microservices.SignalR
{
    public class NotifyHub : Hub
    {
        private readonly Dictionary<string, DictionaryObject> Subscriptions;

        public NotifyHub()
        {
            Subscriptions = new Dictionary<string, DictionaryObject>();
        }

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
            AddDataToDictionary(group, Context.ConnectionId, user, role);
        }

        public void LeaveGroup(string group, string user, string role)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
            RemoveDataFromDictionary(group, Context.ConnectionId, user, role);
        }

        private void AddDataToDictionary(string group, string connectionId, string user, string role)
        {
            RemoveDataFromDictionary(group, connectionId, user, role);

            Subscriptions.Add(connectionId, new DictionaryObject()
            {
                User = user,
                Group = group,
                Role = role,
            });
        }

        private void RemoveDataFromDictionary(string group, string connectionId, string user, string role)
        {
            var subscription = Subscriptions.Values.FirstOrDefault(x => x.Group == group && x.User == user && x.Role == role);
            var key = connectionId;

            if (subscription != null)
                key = Subscriptions.FirstOrDefault(x => x.Value == subscription).Key;

            Subscriptions.Remove(key);
        }

    }

    internal class DictionaryObject
    {
        public string User { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
    }
}
