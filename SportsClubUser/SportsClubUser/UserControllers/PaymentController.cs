using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using SportClubProject.Repository;
using SportClubProject.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportClubProject.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepo PaymentRepository;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentRepo paymentRepository, ILogger<PaymentController> logger)
        {
            PaymentRepository = paymentRepository;
            _logger = logger;
        }


        //save payment

        [HttpPost("/savepayment")]
        public Payment SavePayment(Payment payment)
        {
            try
            {
                _logger.LogInformation("entered into save payment method in payment controller");
                PaymentRepository.SavePaymentDetails(payment);
                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "an error occured while save payment");
                throw;
            }
        }
        [HttpGet("/getpayment")]
        public List<Payment> GetPayment() { 
          return PaymentRepository.GetPaymentList();
        
        }
        
        
    }
}
