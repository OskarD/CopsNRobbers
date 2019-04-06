using System;

namespace Server.Exception
{
    [Serializable]
    public class ConfigurationException : System.Exception
    {
        public ConfigurationException(string message) : base(message)
        {
        }
    }
}