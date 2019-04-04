using System;
using GTANetworkAPI;

namespace Server.Commands
{
    public class GetPosition : Script
    {
        [Command("getpos")]
        public void CMD_GetPos(Client client, string comment = null)
        {
            var output = $"Pos: {client.Position} | Rotation: {client.Rotation}";

            if (comment != null) output += $" | Comment: {comment}";

            Console.WriteLine(output);
            client.SendChatMessage(output);
        }
    }
}