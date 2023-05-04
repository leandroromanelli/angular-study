using Microsoft.AspNetCore.SignalR;

namespace chat_service
{
    public class Chat : Hub
    {
        private readonly ChatContext _chatContext;

        public Chat(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public void NewMessage(string userName, string message)
        {
            Clients.All.SendAsync("newMessage", userName, message);
            _chatContext.Messages.Add(new Message(userName, message));
            _chatContext.SaveChanges();
        }
        
        public void NewUser(string userName)
        {
            Clients.All.SendAsync("newUser", userName);
        }
    }
}
