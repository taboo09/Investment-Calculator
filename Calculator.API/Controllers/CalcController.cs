using Calculator.API.Models;
using Calculator.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcController : ControllerBase
    {
        private readonly ICalculator _calculator;
        private readonly IDataService _dataService;

        public CalcController(ICalculator calculator, IDataService dataService)
        {
            _dataService = dataService;
            _calculator = calculator;
        }

        [HttpPost("interest")]
        public IActionResult CalculateInterest(InterestRequest interestRequest)
        {
            var result = _calculator.InterestResult(interestRequest);

            return Ok(result);
        }

        [HttpPost("investment")]
        public IActionResult CalculateInvestment(InvestmentRequest request)
        {
            var result = _calculator.InvestmentMonthly(request);

            return Ok(result);
        }
    }
}