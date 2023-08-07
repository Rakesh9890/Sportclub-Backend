using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Twilio.Clients;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using SportsProject.Controllers;
using Models;
using System;

namespace SportClubProject.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ITwilioRestClient client;
        private readonly ILogger<SmsController> _logger;

        public SmsController(ITwilioRestClient twilioRest, ILogger<SmsController> logger)
        {
            client = twilioRest;
            _logger = logger;
        }

        [HttpPost("SendSms")]
        public ActionResult<int> SendSms(Smsmodel smsmodel)
        {
            try
            {
                Random random = new Random();
                int otp = random.Next(100000, 999999);
                string otpmessage = smsmodel.Message;
                otpmessage = otpmessage + otp;
                smsmodel.Message = otpmessage;

                var message = MessageResource.Create(
                    to: new PhoneNumber(smsmodel.To),
                    from: new PhoneNumber(smsmodel.From),
                    body: smsmodel.Message,
                    client: client);

                return otp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending SMS.");
                throw;
            }
        }

        //sending booking details
        [HttpPost("sendBooking")]
        public ActionResult<bool> SendBooking(Smsmodel smsmodel)
        {
            try
            {
                _logger.LogInformation("entered into send booking method in sms controller");
                var message = MessageResource.Create(
                    to: new PhoneNumber(smsmodel.To),
                    from: new PhoneNumber(smsmodel.From),
                    body: smsmodel.Message,
                    client: client);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending booking details SMS.");
                throw;
            }
        }
    }
}
