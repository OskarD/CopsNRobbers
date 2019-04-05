using System;
using GTANetworkAPI;

namespace Server.DataModels.Teams
{
    public class Vehicle
    {
        private readonly Random Random = new Random();

        public Vehicle(VehicleHash vehicleHash, int color1 = -1, int color2 = -1)
        {
            VehicleHash = vehicleHash;

            if (color1 == -1)
                color1 = GetRandomColor();
            if (color2 == -1)
                color2 = GetRandomColor();

            Color1 = color1;
            Color2 = color2;
        }

        public VehicleHash VehicleHash { get; }
        public int Color1 { get; }
        public int Color2 { get; }

        private int GetRandomColor()
        {
            return Random.Next(159);
        }
    }
}