using System.Collections.Generic;
using CopsNRobbers_shared.DataModels;
using CopsNRobbers_shared.DataModels.Crimes;
using Server.DataModels;

namespace Server.Events
{
    public static class PlayerWitnessedCrime
    {
        public static void OnPlayerWitnessedCrime(Player witness, Player criminal, Crime crime)
        {
            if (witness.Team == Team.Cops)
            {
                criminal.ReportForCrime(crime);
                return;
            }

            witness.CrimesWitnessed.Add(new KeyValuePair<Player, Crime>(criminal, crime));
        }
    }
}