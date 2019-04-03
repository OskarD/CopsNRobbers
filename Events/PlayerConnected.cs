using GTANetworkAPI;
using Server.DataModels;

namespace Server.Events
{
    public class PlayerConnected : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Client client)
        {
            ServerContext.Players.Add(new Player(client));
        }
    }
}