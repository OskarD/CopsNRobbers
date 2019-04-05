using GTANetworkAPI;

namespace Server.Events
{
    // ReSharper disable once UnusedMember.Global
    public class PlayerDisconnected : Script
    {
        [ServerEvent(Event.PlayerDisconnected)]
        // ReSharper disable once UnusedMember.Global
        public void OnPlayerDisconnected(Client client)
        {
            var player = ServerContext.GetPlayer(client);

            player.Vehicle.Delete();

            ServerContext.Players.Remove(player);
        }
    }
}