namespace Server.DataModels
{
    public class Animation
    {
        public Animation(string animDict, string animName, int flag = 0)
        {
            AnimDict = animDict;
            AnimName = animName;
            Flag = flag;
        }

        public string AnimDict { get; }
        public string AnimName { get; }
        public int Flag { get; }
    }
}