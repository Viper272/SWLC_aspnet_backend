using aspnet_backend.Game.Managers;
using aspnet_backend.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace aspnet_backend.Game
{
    public class GameEngine
    {
        //private readonly static Lazy<GameEngine> _instance = new Lazy<GameEngine>(() => new GameEngine());
        //public static GameEngine Instance { get { return _instance.Value; } }

        private object _locker = new object();


        internal IHubContext<GameHub> _hubContext;
        internal ConnectionManager _connectionManager;


        public GameEngine(IHubContext<GameHub> context)
        {
            _hubContext = context;

            _connectionManager = new ConnectionManager(_locker);
        }

    }
}
