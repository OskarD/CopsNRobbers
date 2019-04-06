using CopsNRobbers_shared.DataModels.Crimes;
using GTANetworkAPI;

namespace Server.Events
{
    // ReSharper disable once UnusedMember.Global
    public class PlayerDeath : Script
    {
        [ServerEvent(Event.PlayerDeath)]
        // ReSharper disable once UnusedMember.Global
        public void OnPlayerDeath(Client client, Client killer, DeathReason reason)
        {
            if (killer != null)
            {
                var killingPlayer = ServerContext.GetPlayer(killer);
                killingPlayer.CrimesCommitted.Add(Crime.Murder);
                killingPlayer.ReportForCrime(Crime.Murder);
            }
        }
    }
}