using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;
using Server.DataModels.Teams;

namespace Server.Commands
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class TeamCommands : Script
    {
        [Command("joincops")]
        public void CMD_JoinCops(Client client)
        {
            ServerContext.GetPlayer(client).Team = Team.Cops;
            client.SendChatMessage("You are now a cop");
        }

        [Command("joinrobbers")]
        public void CMD_JoineRobbers(Client client)
        {
            ServerContext.GetPlayer(client).Team = Team.Robbers;
            client.SendChatMessage("You are now a robber");
        }

        [Command("joinnone")]
        public void CMD_JoinNone(Client client)
        {
            ServerContext.GetPlayer(client).Team = Team.None;
            client.SendChatMessage("You are now nothing");
        }
    }
}