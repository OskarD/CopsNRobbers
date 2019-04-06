using CopsNRobbers_shared.DataModels.Crimes;
using Server.DataModels;

namespace Server.Events
{
    public static class PlayerWasReportedForCrime
    {
        public static void OnPlayerWasReportedForCrime(Player player, Crime crime)
        {
        }
    }
}