using GTANetworkAPI;

namespace Server.DataModels
{
    public class SpawnLocation
    {
        public SpawnLocation(Vector3 position, Vector3 rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Vector3 Position { get; }
        public Vector3 Rotation { get; }
    }
}