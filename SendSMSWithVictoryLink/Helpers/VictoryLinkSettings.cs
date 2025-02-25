using Newtonsoft.Json;

namespace SendSMS.Helpers
{
    public class VictoryLinkSettings
    {
        public string UserName => Environment.GetEnvironmentVariable("VICTORYLINK_USERNAME");
        public string Password => Environment.GetEnvironmentVariable("VICTORYLINK_PASSWORD");
     

    }
}
