using System;
using GTANetworkAPI;
using Server.DataModels;

namespace Server.Events
{
    public class PlayerChangeTeam
    {
        public static void OnPlayerChangeTeam(Player player)
        {
            var playerTeam = player.Team;
            player.Client.SetSkin(playerTeam.GetSkin());
            //NAPI.Player.SpawnPlayer(player.Client, playerTeam.GetSpawnLocation());
            player.Client.RemoveAllWeapons();

            foreach (var weaponHash in playerTeam.GetLoadout())
            {
                player.Client.GiveWeapon(weaponHash, 24);
            }

            if (player.Vehicle != null)
            {
                player.Vehicle.Delete();
            }
            
            player.Vehicle = NAPI.Vehicle.CreateVehicle(
                playerTeam.GetVehicle(), 
                player.Client.Position, 
                0f, 
                0, 0, 
                player.Client.Name, 
                255, 
                false, 
                true, 
                UInt32.MaxValue);

        }
    }
}