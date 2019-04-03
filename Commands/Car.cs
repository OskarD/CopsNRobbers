using System;
using System.Security.Cryptography;
using GTANetworkAPI;

namespace Server.Commands
{
    public class Car : Script
    {
        [Command("car")]
        public void CMD_Car(Client client)
        {
            var player = ServerContext.GetPlayer(client);
            player.Vehicle.Position = client.Position.Around(4f);
            player.Vehicle.Dimension = client.Dimension;
        }
    }
}