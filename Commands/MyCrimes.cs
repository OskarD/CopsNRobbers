using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CopsNRobbers_shared.DataModels.Crimes;
using GTANetworkAPI;

namespace Server.Commands
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class MyCrimes : Script
    {
        [Command("mycrimes")]
        public void CMD_MyCrimes(Client client)
        {
            var player = ServerContext.GetPlayer(client);

            var output = "Your crimes: ";

            var crimes = new Dictionary<Crime, int>();
            player.CrimesWantedFor.ForEach(crime =>
            {
                if (crimes.ContainsKey(crime))
                    crimes[crime]++;
                else
                    crimes.Add(crime, 1);
            });

            foreach (var crime in crimes.Keys)
            {
                crimes.TryGetValue(crime, out var count);
                output += $"{crime} ({count}), ";
            }

            client.SendChatMessage(output.Trim().Trim(','));
        }
    }
}