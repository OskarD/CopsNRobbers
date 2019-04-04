using GTANetworkAPI;
using Server.DataModels;

namespace Server.Events
{
    public class PlayerChangeTeam
    {
        public static void OnPlayerChangeTeam(Player player)
        {
            var playerTeam = player.Team;

            player.Client.Team = playerTeam.GetCientTeam(); // TODO: Delete, API not implemented yet

            player.Client.SetSkin(playerTeam.GetSkin());

            var spawnLocation = playerTeam.GetSpawnLocation();
            NAPI.Player.SpawnPlayer(player.Client,
                new Vector3(spawnLocation.Position.X, spawnLocation.Position.Y, spawnLocation.Position.Z),
                spawnLocation.Rotation.Z);
            player.Client.SendChatMessage(spawnLocation.Rotation.ToString());

            player.Client.RemoveAllWeapons();

            foreach (var weaponHash in playerTeam.GetLoadout()) player.Client.GiveWeapon(weaponHash, 24);

            if (player.Vehicle != null) player.Vehicle.Delete();

            player.Vehicle = NAPI.Vehicle.CreateVehicle(
                playerTeam.GetVehicle(),
                player.Client.Position,
                0f,
                0, 0,
                player.Client.Name,
                255,
                false,
                true,
                uint.MaxValue);
        }
    }
}