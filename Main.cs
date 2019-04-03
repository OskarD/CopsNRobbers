using System;
using GTANetworkAPI;

namespace Server
{
    public class Main : Script
    {
        public Main()
        {
            Console.WriteLine("Hello World");
        }

        [Command("test")]
        public void CMD_Test(Client client)
        {
            client.SendChatMessage("Test");
        }
    }
}