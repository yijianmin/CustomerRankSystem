using CustomerRankSystem.Core;
using CustomerRankSystem.Dto;
using CustomerRankSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomerRankSystem.Controllers
{
    /// <summary>
    /// Customer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        /// <summary>
        /// update customer scores
        /// </summary>
        /// <param name="customerid"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        [HttpPost("/customer/{customerid}/score/{score}")]
        public async Task<OutputResult<Customer>> UpdateScore(
            [Range(minimum: 1, maximum: Int64.MaxValue, ErrorMessage = "Please enter the correct CustomerId")] Int64 customerid,
            [Range(minimum: -1000, maximum: 1000, ErrorMessage = "Please enter scores in the correct range")] int score)
        {
            var result = _customerService.UpdateCustomerScore(customerid, score);
            return new OutputResult<Customer>(result);
        }

        /// <summary>
        /// InitData
        /// </summary>
        /// <returns></returns>
        [HttpPost("InitData")]
        public OutputResult InitData()
        {
            _customerService.InitData();
            return new OutputResult(EnumResultCode.Ok, "Init succeed."); 
        }
    }
}