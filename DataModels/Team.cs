using System.Collections.Generic;
using GTANetworkAPI;

namespace Server.DataModels
{
    public enum Team
    {
        None,
        Cops,
        Robbers
    }

    static class TeamMethods
    {
        // TODO: Array of skins per team
        private static readonly Dictionary<Team, PedHash> TeamSkins = new Dictionary<Team, PedHash>
        {
            {Team.None, PedHash.Devin},
            {Team.Cops, PedHash.Cop01SMY},
            {Team.Robbers, PedHash.JewelThief}
        };
        
        public static PedHash GetSkin(this Team team)
        {
            return TeamSkins[team];
        }
    }
}