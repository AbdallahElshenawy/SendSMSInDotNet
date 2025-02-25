using Microsoft.AspNetCore.Mvc;
using SendSMS.Dtos;
using SendSMS.Services;
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
                int result = await smsService.Send(dto.MobileNumbers, dto.Body);
                if (result == 0)
                {
                    return Ok("SMS sent successfully");
                }
                return BadRequest($"SMS failed with status code: {result}.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"API request failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
