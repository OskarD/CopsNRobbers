using System.Collections.Generic;
using GTANetworkAPI;
using Server.DataModels;

namespace Server
{
    public class ServerContext
    {
        public static readonly List<Player> Players = new List<Player>();

        public static Player GetPlayer(Client client)
        {
            return Players.Find(player => player.Client == client);
        }
    }
}