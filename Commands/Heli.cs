using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Server.Commands
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Heli : Script
    {
        [Command("heli")]
        public void CMD_Heli(Client client)
        {
            NAPI.Vehicle.CreateVehicle(VehicleHash.Volatus, client.Position, 0f, 111, 98, "SHARMIN", 255, false, true,
                uint.MinValue);
        }
    }
}