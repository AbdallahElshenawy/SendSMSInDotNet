namespace SendSMS.Dtos
{
    public class SendSMSDto
    {
        public List<string> MobileNumbers { get; set; }
        public string Body { get; set; }
    }
}
