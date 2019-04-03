using GTANetworkAPI;
using Server.DataModels;

namespace Server.Events
{
    public class PlayerDisconnected : Script
    {
        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Client client)
        {
            var player = ServerContext.GetPlayer(client);
            
            player.Vehicle.Delete();
            
            ServerContext.Players.Remove(player);
        }
    }
}