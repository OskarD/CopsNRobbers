using System;
using System.Diagnostics.CodeAnalysis;
using CopsNRobbers_shared.DataModels;
using GTANetworkAPI;
using Server.DataModels;
using Server.DataModels.Teams;

namespace Server.Commands
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Car : Script
    {
        private readonly Spawn[] _copCarSpawns =
        {
            new Spawn(new Vector3(471.5217, -1024.819, 27.79317),
                new Vector3(0.6019828, -1.022058, 273.3064)), // back_exit1
            new Spawn(new Vector3(481.571, -1024.074, 27.60853),
                new Vector3(1.411033, -0.4795873, 274.5071)), // back_exit2
            new Spawn(new Vector3(478.3934, -1018.725, 27.583),
                new Vector3(0.9191707, -1.187416, 270.7653)), // back_exit3
            new Spawn(new Vector3(463.2304, -1015.155, 27.68824),
                new Vector3(0.1577419, 0.03351191, 91.72626)), // small_garage1
            new Spawn(new Vector3(463.1684, -1019.887, 27.7085),
                new Vector3(0.2145668, 0.02947844, 90.32666)), // small_garage2
            new Spawn(new Vector3(431.0638, -1006.713, 27.16996),
                new Vector3(15.99813, -0.2579778, 180.0639)), // garage_exit1
            new Spawn(new Vector3(436.0274, -1006.892, 27.15185),
                new Vector3(13.76173, -0.8721229, 176.8103)) // garage_exit2
        };

        private readonly Random _random = new Random();

        [Command("color")]
        public void CMD_Color(Client client, int color1, int color2)
        {
            if (!client.IsInVehicle)
                return;

            client.Vehicle.PrimaryColor = color1;
            client.Vehicle.SecondaryColor = color2;
        }

        [Command("car")]
        public void CMD_Car(Client client)
        {
            var player = ServerContext.GetPlayer(client);

            if (player.Team == Team.Cops)
            {
                LoadCopVehicle(player);
                return;
            }

            if (player.Vehicle.Dimension == client.Dimension)
                return;

            player.Vehicle.Position = client.Position.Around(4f);
            player.Vehicle.Dimension = client.Dimension;
        }

        private void LoadCopVehicle(Player player)
        {
            var job = new Job();
            job.AddObjective(new Objective(new Vector3(451.9421, -987.8945, 26.6742), 2f, () =>
            {
                var vehicleSpawn = GetRandomCopCarSpawn();
                player.Vehicle.Position = vehicleSpawn.Position;
                player.Vehicle.Rotation = vehicleSpawn.Rotation;
                player.Vehicle.Dimension = player.Client.Dimension;
                player.Client.SetIntoVehicle(player.Vehicle, VehicleSeat.Driver.GetHashCode());
            }));
            player.CurrentJob = job;

            player.Client.SendChatMessage("Your vehicle is in the garage. The door is near the cells.");
        }

        private Spawn GetRandomCopCarSpawn()
        {
            return _copCarSpawns[_random.Next(_copCarSpawns.Length)];
        }
    }
}