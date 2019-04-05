using System;
using GTANetworkAPI;

namespace Server.DataModels
{
    public class Objective
    {
        public Objective(Vector3 position, float size, Action postAction = null)
        {
            Position = position;
            Size = size;
            PostAction = postAction;
        }

        public Vector3 Position { get; }
        public float Size { get; }
        public Action PostAction { get; }
    }
}