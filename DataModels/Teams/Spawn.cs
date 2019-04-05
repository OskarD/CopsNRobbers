using GTANetworkAPI;

namespace Server.DataModels.Teams

{
    public class Spawn
    {
        public Spawn(Vector3 position, Vector3 rotation, Animation animation = null)
        {
            Position = position;
            Rotation = rotation;
            Animation = animation;
        }

        public Vector3 Position { get; }
        public Vector3 Rotation { get; }
        public Animation Animation { get; }
    }
}