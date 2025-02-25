using Microsoft.Extensions.Options;
using SendSMS.Helpers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SendSMS.Services
{
    public class SMSService : ISMSService
    {
        private readonly TwilioSettings _twilio;

        public SMSService(TwilioSettings twilio)
        {
            _twilio = twilio;
            if (string.IsNullOrEmpty(_twilio.AccountSID) ||
                string.IsNullOrEmpty(_twilio.AuthToken) ||
                string.IsNullOrEmpty(_twilio.TwilioPhoneNumber))
            {
                throw new InvalidOperationException("Twilio environment variables (TWILIO_ACCOUNT_SID, TWILIO_AUTH_TOKEN, TWILIO_PHONE_NUMBER) must be set.");
            }
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);
        }

        public async Task<MessageResource> Send(string mobileNumber, string body)
        {

            var result =  await MessageResource.CreateAsync(
                    body: body,
                   from: new PhoneNumber(_twilio.TwilioPhoneNumber),
                to: new PhoneNumber(mobileNumber)
                );

            return result;
        }
    }
}
