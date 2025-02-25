using Twilio.Rest.Api.V2010.Account;

namespace SendSMS.Services
{
    public interface ISMSService
    {
        Task<MessageResource> Send(string mobileNumber, string body);
    }
}
