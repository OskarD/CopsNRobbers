using System;
using GTANetworkAPI;
using Server.DataModels;

namespace Server.Events
{
    // ReSharper disable once UnusedMember.Global
    public class PlayerConnected : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        // ReSharper disable once UnusedMember.Global
        public void OnPlayerConnected(Client client)
        {
            ServerContext.Players.Add(new Player(client));
            NAPI.Chat.SendChatMessageToAll($"{client.Name} has connected.");
            Console.WriteLine($"{client.Name} has connected.");
        }
    }
}