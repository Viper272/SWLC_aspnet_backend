using Microsoft.AspNetCore.SignalR;

namespace aspnet_backend.Game.Managers
{
    public class ConnectionManager
    {

        private object _locker;

        public ConnectionManager(object locker)
        {
            _locker = locker;
        }


        public void OnConnected(string connectionID) { Console.WriteLine("DI Worked"); }
        
        //Reconnect
        //Disconnect
    }
}
