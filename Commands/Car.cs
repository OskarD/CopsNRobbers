using GTANetworkAPI;
using Server.DataModels;

namespace Server.Commands
{
    public class Car : Script
    {
        [Command("car")]
        public void CMD_Car(Client client)
        {
            var player = ServerContext.GetPlayer(client);

            if (player.Vehicle.Dimension == client.Dimension)
                return;

            player.Vehicle.Position = client.Position.Around(4f);
            player.Vehicle.Dimension = client.Dimension;
        }

        [Command("copcar")]
        public void CMD_CopCar(Client client)
        {
            var player = ServerContext.GetPlayer(client);

            var job = new Job();
            job.AddObjective(new Objective(new Vector3(451.9421, -987.8945, 26.6742), 2));
            player.CurrentJob = job;
        }
    }
}