using GTANetworkAPI;

namespace Server
{
    // ReSharper disable once UnusedMember.Global
    public class JobHandler : Script
    {
        [RemoteEvent("job_objective_completed")]
        public void Remote_Event_JobObjectiveCompleted(Client client)
        {
            var player = ServerContext.GetPlayer(client);
            player.CompleteJobObjective();
        }
    }
}