using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Server.Commands
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Animation : Script
    {
        [Command("anim")]
        public void CMD_Anim(Client client, string animDict, string animName, int flag)
        {
            client.StopAnimation();
            client.PlayAnimation(animDict, animName, flag);
        }
    }
}