using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendSMS.Dtos;
using SendSMS.Services;
using Twilio.Rest.Api.V2010.Account;

namespace SendSMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController(ISMSService smsService ) : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> Send(SendSMSDto dto)
        {
            try
            {
                MessageResource result = await smsService.Send(dto.MobileNumber, dto.Body);

                if (result.Status == MessageResource.StatusEnum.Failed ||
                    result.Status == MessageResource.StatusEnum.Undelivered)
                {
                    return BadRequest(result.ErrorMessage);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error sending SMS: {ex.Message}");
            }
        }
    }
}
