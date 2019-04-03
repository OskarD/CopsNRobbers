using System;
using GTANetworkAPI;

namespace Server.Commands
{
    public class GetPosition : Script
    {
        [Command("getpos")]
        public void CMD_GetPos(Client client)
        {
            Console.WriteLine(client.Position);
            client.SendChatMessage(client.Position.ToString());
        }
    }
}