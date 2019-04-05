using GTANetworkAPI;

namespace Server.DataModels.Teams
{
    public class LoadOutWeapon
    {
        public LoadOutWeapon(WeaponHash weaponHash, int ammoAmount = 1)
        {
            WeaponHash = weaponHash;
            AmmoAmount = ammoAmount;
        }

        public WeaponHash WeaponHash { get; }
        public int AmmoAmount { get; }
    }
}