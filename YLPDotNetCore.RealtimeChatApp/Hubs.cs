using Microsoft.AspNetCore.SignalR;

namespace YLPDotNetCore.RealtimeChatApp
{
    public class ChatHub : Hub
    {
        public async Task ServerReceiveMessage(string user, string message)
        {
            await Clients.All.SendAsync("ClientReceiveMessage", user, message);
        }
    }
}
