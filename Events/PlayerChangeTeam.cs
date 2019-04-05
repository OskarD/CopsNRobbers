using GTANetworkAPI;
using Server.DataModels;
using Server.DataModels.Teams;

namespace Server.Events
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PlayerChangeTeam
    {
        public static void OnPlayerChangeTeam(Player player)
        {
            player.Client.Team = player.Team.GetClientTeam(); // TODO: Delete, API not implemented yet
            player.Client.SetSkin(player.Team.GetSkin());
            SpawnPlayer(player);
            SetPlayerWeapons(player);
            CreatePlayerVehicle(player);
        }

        private static void SpawnPlayer(Player player)
        {
            var spawn = player.Team.GetSpawn();
            NAPI.Player.SpawnPlayer(player.Client,
                new Vector3(spawn.Position.X, spawn.Position.Y, spawn.Position.Z),
                spawn.Rotation.Z);

            var animation = spawn.Animation;
            if (animation != null)
                player.Client.PlayAnimation(animation.AnimDict, animation.AnimName, animation.Flag);
        }

        private static void SetPlayerWeapons(Player player)
        {
            player.Client.RemoveAllWeapons();
            foreach (var loadOutWeapon in player.Team.GetLoadOut())
                player.Client.GiveWeapon(loadOutWeapon.WeaponHash, loadOutWeapon.AmmoAmount);
            player.Client.GiveWeapon(WeaponHash.Unarmed, 1);
        }

        private static void CreatePlayerVehicle(Player player)
        {
            if (player.Vehicle != null) player.Vehicle.Delete();

            player.Vehicle = NAPI.Vehicle.CreateVehicle(
                player.Team.GetVehicle(),
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