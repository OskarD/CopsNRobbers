using System;
using System.Diagnostics.CodeAnalysis;
using CopsNRobbers_shared.DataModels;
using CopsNRobbers_shared.DataModels.Crimes;
using GTANetworkAPI;
using Server.Events;

namespace Server.Handlers
{
    // ReSharper disable once UnusedMember.Global
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class CrimeHandler : Script
    {
        [RemoteEvent("crime_committed")]
        public void Remote_Event_CrimeCommitted(Client criminalClient, string crimeString)
        {
            if (ServerContext.GetPlayer(criminalClient).Team == Team.Cops) return;

            var crime = (Crime) Enum.Parse(typeof(Crime), crimeString);
            var witnesses = NAPI.Player.GetPlayersInRadiusOfPlayer(60, criminalClient);
            if (witnesses.Count == 0)
                return;

            var criminalPlayer = ServerContext.GetPlayer(criminalClient);
            criminalPlayer.CrimesCommitted.Add(crime);

            foreach (var witnessClient in witnesses)
            {
                if (witnessClient == criminalClient)
                    continue;

                var witnessPlayer = ServerContext.GetPlayer(witnessClient);
                PlayerWitnessedCrime.OnPlayerWitnessedCrime(witnessPlayer, criminalPlayer, crime);
            }
        }
    }
}