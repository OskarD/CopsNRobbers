using GTANetworkAPI;
using Server.Events;

namespace Server.DataModels
{
    public class Player
    {
        public Client Client { get; }

        private Team team;
        public Team Team
        {
            get { return team; }
            set {
                PlayerChangeTeam.OnPlayerChangeTeam(this, value);
                team = value;
            }
        }

        public Player(Client client)
        {
            Client = client;
            Team = Team.None;
        }

        public void SetTeamSkin(Team newTeam)
        {
            Client.SetSkin(newTeam.GetSkin());
        }
    }
}