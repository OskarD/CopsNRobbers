using System.Collections.Generic;
using CopsNRobbers_shared.DataModels.Crimes;
using Server.Exception;
using static CopsNRobbers_shared.DataModels.Crimes.Classification;
using static CopsNRobbers_shared.DataModels.Crimes.Crime;

namespace Server.DataModels
{
    internal static class CrimeMethods
    {
        private static readonly Dictionary<Crime, Classification> Classifications =
            new Dictionary<Crime, Classification>
            {
                {UnlawfulDischargeOfWeapon, Misdemeanor},
                {AssaultWithADeadlyWeapon, Felony},
                {Murder, Felony}
            };

        private static readonly Dictionary<Crime, int> Fines = new Dictionary<Crime, int>
        {
            {UnlawfulDischargeOfWeapon, 150},
            {AssaultWithADeadlyWeapon, 5_000},
            {Murder, 20_000}
        };

        public static Classification GetClassification(this Crime crime)
        {
            if (!Classifications.TryGetValue(crime, out var classification))
                throw new ConfigurationException($"Crime does not have a configured classification: {crime}");

            return classification;
        }

        public static int GetFine(this Crime crime)
        {
            if (!Fines.TryGetValue(crime, out var fine))
                throw new ConfigurationException($"Crime does not have a configured classification: {crime}");

            return fine;
        }
    }
}