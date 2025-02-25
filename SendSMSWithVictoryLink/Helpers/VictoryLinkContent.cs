using Newtonsoft.Json;

namespace SendSMSWithVictoryLink.Helpers
{
    public class VictoryLinkContent
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [JsonProperty("SMSSender")]
        public string Sender { get; set; }
        [JsonProperty("Anis")]
        public string[] Mobile { get; set; }
        [JsonProperty("SMSText")]
        public string Message { get; set; }
        [JsonProperty("SMSLang")]
        public string Language { get; set; }
        public Guid SMSID { get; set; }
    }
}
