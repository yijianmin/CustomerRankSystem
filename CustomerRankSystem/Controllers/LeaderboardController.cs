using CustomerRankSystem.Core;
using CustomerRankSystem.Dto;
using CustomerRankSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRankSystem.Controllers
{
    /// <summary>
    /// Customer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly ILogger<LeaderboardController> _logger;
        private readonly CustomerService _customerService;

        public LeaderboardController(ILogger<LeaderboardController> logger, CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        /// <summary>
        /// Get customers by rank
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [HttpGet("/[controller]")]
        public async Task<OutputResult<List<Customer>>> GetCustomersByRank([FromQuery] GetCustomersByRankReq args)
        {
            var result = _customerService.GetCustomersByRank(args);
            return new OutputResult<List<Customer>>(result);
        }

        /// <summary>
        /// Get customers by ID
        /// </summary>
        /// <param name="customerid"></param>
        /// <param name="high"></param>
        /// <param name="low"></param>
        /// <returns></returns>
        [HttpGet("/[controller]/{customerid}")]
        public async Task<OutputResult<List<Customer>>> GetCustomersById(Int64 customerid, int high, int low)
        {
            var result = _customerService.GetCustomersById(customerid, high, low);
            return new OutputResult<List<Customer>>(result);
        }
    }
}