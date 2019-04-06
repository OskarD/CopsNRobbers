using System;
using System.Collections.Generic;
using CopsNRobbers_shared.DataModels;
using CopsNRobbers_shared.DataModels.Crimes;
using GTANetworkAPI;
using Server.Events;

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

        public HashSet<KeyValuePair<Player, Crime>> CrimesWitnessed { get; } =
            new HashSet<KeyValuePair<Player, Crime>>();

        public HashSet<Crime> CrimesCommitted { get; } = new HashSet<Crime>();
        public List<Crime> CrimesWantedFor { get; } = new List<Crime>();

        public int OutstandingFines
        {
            get
            {
                var outstandingFines = 0;
                CrimesWantedFor.ForEach(crime => { outstandingFines += crime.GetFine(); });
                return outstandingFines;
            }
        }

        public int WantedLevel
        {
            get
            {
                if (OutstandingFines == 0)
                    return 0;
                if (OutstandingFines < 500)
                    return 1;
                if (OutstandingFines < 3_000)
                    return 2;
                if (OutstandingFines < 10_000)
                    return 3;
                if (OutstandingFines < 20_000)
                    return 4;
                return 5;
            }
        }

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

        public void ReportForCrime(Crime crime)
        {
            if (!CrimesCommitted.Contains(crime))
                throw new ArgumentException($"Player {Client.Name} did not commit reported crime {crime}");

            var previousWantedLevel = WantedLevel;

            RemoveWitnesses(crime);
            CrimesCommitted.Remove(crime);
            CrimesWantedFor.Add(crime);
            Client.WantedLevel = WantedLevel;

            // TODO: Refactor out of this place
            if (WantedLevel > previousWantedLevel)
            {
                NotifyCops(crime, previousWantedLevel);

                if (previousWantedLevel == 0)
                    Client.SendChatMessage($"~r~You are now wanted! (Level {WantedLevel})");
                else
                    Client.SendChatMessage(
                        $"~r~Your wanted level has been increased from {previousWantedLevel} to {WantedLevel}");
            }
        }

        private void RemoveWitnesses(Crime crime)
        {
            var crimeWitnessed = new KeyValuePair<Player, Crime>(this, crime);
            ServerContext.Players.ForEach(player =>
            {
                if (player.CrimesWitnessed.Contains(crimeWitnessed)) player.CrimesWitnessed.Remove(crimeWitnessed);
            });
        }

        private void NotifyCops(Crime crime, int previousWantedLevel)
        {
            ServerContext.Players.FindAll(player => player.Team == Team.Cops).ForEach(cop =>
            {
                cop.Client.SendChatMessage(
                    $"~b~Suspect {Client.Name} has received wanted level {WantedLevel}");
            });
        }

        public void ResetStats()
        {
            CrimesCommitted.Clear();
            CrimesWitnessed.Clear();
            CrimesWantedFor.Clear();
        }
    }
}