using GTANetworkAPI;

namespace Server.Commands
{
    public class Gun : Script
    {
        [Command("gun")]
        public void CMD_Gun(Client client)
        {
            client.GiveWeapon(WeaponHash.Pistol, 50);
        }
    }
}