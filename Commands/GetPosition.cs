using System;
using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Server.Commands
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class GetPosition : Script
    {
        [Command("getpos")]
        public void CMD_GetPos(Client client, string comment = null)
        {
            var output =
                $"Pos: {client.Position} | Rotation: {client.Rotation.X} {client.Rotation.Y} {client.Rotation.Z}";

            if (client.IsInVehicle)
                output +=
                    $" | VehiclePos: {client.Vehicle.Position} | VehicleRotation: {client.Vehicle.Rotation.X} {client.Vehicle.Rotation.Y} {client.Vehicle.Rotation.Z}";

            if (comment != null) output += $" | Comment: {comment}";

            Console.WriteLine(output);
            client.SendChatMessage(output);
        }
    }
}