using System;
using GTANetworkAPI;
using Server.DataModels.Teams;
using Server.Events;
using Vehicle = GTANetworkAPI.Vehicle;

namespace Server.DataModels
{
    public class Player // TODO: Extend Client?
    {
        private Job _currentJob;

        private Team _team;

        public Player(Client client)
        {
            Client = client;
            Team = Team.None;
        }

        public Client Client { get; }

        public Team Team
        {
            get => _team;
            set
            {
                _team = value;
                PlayerChangeTeam.OnPlayerChangeTeam(this);
            }
        }

        public Vehicle Vehicle { get; set; }

        public Job CurrentJob
        {
            get => _currentJob;
            set
            {
                _currentJob = value;

                if (value != null) LoadJobObjective();
            }
        }

        private bool IsInJobObjective =>
            Client.Position.DistanceTo2D(CurrentJob.CurrentObjective.Position) <= CurrentJob.CurrentObjective.Size
            && Math.Abs(Client.Position.Z) - Math.Abs(CurrentJob.CurrentObjective.Position.Z) <
            CurrentJob.CurrentObjective.Size;

        private void LoadJobObjective()
        {
            Client.TriggerEvent("load_job_objective", CurrentJob.CurrentObjective.Position,
                CurrentJob.CurrentObjective.Size);
        }

        public void CompleteJobObjective()
        {
            if (!IsInJobObjective) return;

            CurrentJob.CurrentObjective.PostAction?.Invoke();

            CurrentJob.Objectives.Dequeue();

            if (CurrentJob.CurrentObjective == null)
            {
                CurrentJob = null;
                return;
            }

            LoadJobObjective();
        }
    }
}