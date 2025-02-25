namespace SendSMS.Services
{
    public interface ISMSService
    {
        Task<int> Send(List<string> mobileNumbers, string body);
    }
}
