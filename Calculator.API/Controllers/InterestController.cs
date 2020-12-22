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

        public CalcController(ICalculator calculator)
        {
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
            var result = _calculator.InvestmentResult(request);

            return Ok(result);
        }
    }
}