using aspnet_backend.Game.Managers;

namespace aspnet_backend.Game
{
    public class GameEngine
    {

        private readonly static Lazy<GameEngine> _instance = new Lazy<GameEngine>(() => new GameEngine());
        public static GameEngine Instance { get { return _instance.Value; } }

        internal ConnectionManager _connectionManager;

        private GameEngine()
        {
            _connectionManager = new ConnectionManager();
        }



    }
}
