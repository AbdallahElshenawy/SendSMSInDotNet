namespace SendSMS.Helpers
{
    public class TwilioSettings
    {
        public string AccountSID => Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        public string AuthToken => Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
        public string TwilioPhoneNumber => Environment.GetEnvironmentVariable("TWILIO_PHONE_NUMBER");
    }
}
