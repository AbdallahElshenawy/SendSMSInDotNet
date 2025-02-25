using Microsoft.Extensions.Options;
using SendSMS.Helpers;
using System.Text.Json;
using System.Text;
using SendSMS.Services;
using Newtonsoft.Json;
using SendSMSWithVictoryLink.Helpers;

public class SMSService : ISMSService
{
    private readonly VictoryLinkSettings _settings;
    private readonly HttpClient _httpClient;

    public SMSService(IOptions<VictoryLinkSettings> settings, HttpClient httpClient)
    {
        _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
        _httpClient = httpClient;

        if (string.IsNullOrEmpty(_settings.UserName) ||
            string.IsNullOrEmpty(_settings.Password))
        {
            throw new InvalidOperationException("VictoryLink environment variables (VICTORYLINK_USERNAME, VICTORYLINK_PASSWORD) must be set.");
        }
    }

    public async Task<int> Send(List<string> mobileNumbers, string body)
    {
        var request = new VictoryLinkContent
        {
            UserName = _settings.UserName, // From env var
            Password = _settings.Password, // From env var
            Sender = "DEXEFCO",     
            Mobile = mobileNumbers.Select(m => $"{m},{Guid.NewGuid()}").ToArray(), // "number,guid"
            Message = body,
            Language = VictoryLinkLanguageEnum.A.ToString(),
        };
        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(
            "https://smsvas.vlserv.com/VLSMSPlatformResellerAPI/NewSendingAPI/api/SMSSender/SendToMany",
            content);

        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        return int.Parse(responseString);

    }
    }