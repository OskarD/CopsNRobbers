using CopsNRobbers_shared.DataModels;
using CopsNRobbers_shared.DataModels.Crimes;
using Server.DataModels;

namespace Server.Events
{
    public static class PlayerWasReportedForCrime
    {
        public static void OnPlayerWasReportedForCrime(Player player, Crime crime)
        {
            player.Client.WantedLevel = player.WantedLevel;
            NotifyCops(player, crime);
            player.Client.SendChatMessage($"Your wanted level: {player.WantedLevel}");
        }

        private static void NotifyCops(Player criminal, Crime crime)
        {
            ServerContext.Players.FindAll(player => player.Team == Team.Cops).ForEach(cop =>
            {
                cop.Client.SendChatMessage(
                    $"~b~Crime reported: {crime}, name: {criminal.Client.Name}, wanted level: {criminal.WantedLevel}");
            });
        }
    }
}