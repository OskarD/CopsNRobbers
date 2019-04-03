using GTANetworkAPI;
using Server.Events;
using Vehicle = GTANetworkMethods.Vehicle;

namespace Server.DataModels
{
    public class Player
    {
        public Client Client { get; }

        private Team team;
        public Team Team
        {
            get => team;
            set {
                team = value;
                PlayerChangeTeam.OnPlayerChangeTeam(this);
            }
        }
        
        public GTANetworkAPI.Vehicle Vehicle { get; set; }

        public Player(Client client)
        {
            Client = client;
            Team = Team.None;
        }
    }
}