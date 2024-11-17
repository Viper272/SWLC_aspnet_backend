using aspnet_backend.Game;
using Microsoft.AspNetCore.SignalR;

namespace aspnet_backend.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameEngine _game;
        //public GameHub() : this(GameEngine.Instance) { }
        
        
        public GameHub(GameEngine game) 
        {  
            _game = game;
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine(Context.ConnectionId  + "Has Connected to Lobby Manager");
            _game._connectionManager.OnConnected(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        //OnDisconnect

        //InitPlayer
        //JoinLobby

    }
}
