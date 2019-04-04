using GTANetworkAPI;

namespace Server
{
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