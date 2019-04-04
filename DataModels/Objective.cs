using GTANetworkAPI;

namespace Server.DataModels
{
    public class Objective
    {
        public Objective(Vector3 position, float size)
        {
            Position = position;
            Size = size;
        }

        public Vector3 Position { get; }
        public float Size { get; }
    }
}