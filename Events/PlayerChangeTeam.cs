using GTANetworkAPI;
using Server.DataModels;

namespace Server.Events
{
    public class PlayerChangeTeam
    {
        public static void OnPlayerChangeTeam(Player player, Team newTeam)
        {
            player.SetTeamSkin(newTeam);
        }
    }
}