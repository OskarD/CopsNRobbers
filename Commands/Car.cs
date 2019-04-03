using System;
using System.Security.Cryptography;
using GTANetworkAPI;

namespace Server.Commands
{
    public class Car : Script
    {
        [Command("car")]
        public void spawnCar(Client client)
        {
            NAPI.Vehicle.CreateVehicle(VehicleHash.ItaliGTB2, client.Position, 0f, 13, 22, "SHARMIN", 255, false, true, UInt32.MinValue);
        }
    }
}