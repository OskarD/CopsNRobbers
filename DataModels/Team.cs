using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using GTANetworkAPI;

namespace Server.DataModels
{
    public enum Team
    {
        None,
        Cops,
        Robbers
    }

    static class TeamMethods
    {
        private static readonly Random Random = new Random();
        
        // TODO: Array of skins per team
        private static readonly Dictionary<Team, PedHash[]> Skins = new Dictionary<Team, PedHash[]>
        {
            {Team.None, new[] {PedHash.Devin}},
            {Team.Cops, new[]
            {
                PedHash.Cop01SMY,
                PedHash.Cop01SFY,
                PedHash.Hwaycop01SMY
            }},
            {Team.Robbers, new[]
            {
                PedHash.JewelThief,
                PedHash.Antonb,
                PedHash.Jesus01
            }}
        };
        
        private static readonly Vector3 SpawnMissionRow = new Vector3(428.697, -979.7612, 30.71029);
        private static readonly Vector3 SpawnSomeBuilding = new Vector3(384.2621, -1025.798, 29.49788);

        private static readonly Dictionary<Team, Vector3[]> Spawns = new Dictionary<Team, Vector3[]>
        {
            {Team.None, new[] {SpawnSomeBuilding}},
            {Team.Cops, new[] {SpawnMissionRow}},
            {Team.Robbers, new[] {SpawnSomeBuilding}}
        };

        private static readonly Dictionary<Team, WeaponHash[]> Loadouts = new Dictionary<Team, WeaponHash[]>
        {
            {Team.None, new[]
            {
                WeaponHash.Snowball
            }},
            {Team.Cops, new[]
            {
                WeaponHash.Nightstick,
                WeaponHash.Flashlight,
                WeaponHash.Pistol
            }},
            {Team.Robbers, new[]
            {
                WeaponHash.Bat
            }}
        };

        private static readonly Dictionary<Team, VehicleHash[]> Vehicles = new Dictionary<Team, VehicleHash[]>
        {
            {Team.None, new[]
            {
                VehicleHash.Asea,
                VehicleHash.Asterope,
                VehicleHash.Emperor,
                VehicleHash.Premier
            }},
            {Team.Cops, new[]
            {
                VehicleHash.Police,
                VehicleHash.Police2,
                VehicleHash.Police3
            }},
            {Team.Robbers, new[]
            {
                VehicleHash.Fugitive,
                VehicleHash.Tailgater,
                VehicleHash.Superd,
                VehicleHash.Schafter5,
                VehicleHash.Intruder
            }}
        };

        public static PedHash GetSkin(this Team team)
        {
            var randomizedIndex = Random.Next(0, Skins[team].Length);
            return Skins[team][randomizedIndex];
        }

        public static Vector3 GetSpawnLocation(this Team team)
        {
            var randomizedIndex = Random.Next(0, Spawns[team].Length);
            return Spawns[team][randomizedIndex];
        }

        public static WeaponHash[] GetLoadout(this Team team)
        {
            return Loadouts[team];
        }

        public static VehicleHash GetVehicle(this Team team)
        {
            var randomizedIndex = Random.Next(0, Vehicles[team].Length);
            return Vehicles[team][randomizedIndex];
        }
    }
}