using System.Diagnostics.CodeAnalysis;
using CopsNRobbersFrontend.Crimes;
using GTANetworkAPI;

namespace Server.Handlers
{
    // ReSharper disable once UnusedMember.Global
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class CrimeHandler : Script
    {
        [RemoteEvent("crime_committed")]
        public void Remote_Event_JobObjectiveCompleted(Client client, object[] arguments)
        {
            var crime = (Crime) arguments[0];
            var player = ServerContext.GetPlayer(client);
            client.SendChatMessage($"Received crime: {crime}");
            // TODO: Add crimes to player
            client.WantedLevel++; // TODO: Not implemented yet

            foreach (var witnessClient in NAPI.Player.GetPlayersInRadiusOfPlayer(50, client))
            {
                if (witnessClient == client)
                    continue;

                client.SendChatMessage($"{witnessClient.Name} saw you!");
                // TODO: Add crime in witness context
            }
        }
    }
}