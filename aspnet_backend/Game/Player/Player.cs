using Microsoft.AspNetCore.SignalR;

namespace aspnet_backend.Game.User
{
    public class Player
    {
        public bool connected { get; set; }
        public string ConnectionID { get; set; }

        public Player(string connectionID)
        {
            connected = true;
            ConnectionID = connectionID;
        }

        public async Task PushToClient(string message, IHubContext hubContext)
        {
            await hubContext.Clients.Client(ConnectionID).SendAsync(message);
        }
    }
}
