using System.Threading.Tasks;
using Calculator.API.Models;
using Calculator.API.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpPost("file")]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromForm] string info)
        {
            if (file == null || file.Length == 0) return BadRequest("File cannot be empty!");

            var infoFile = JsonConvert.DeserializeObject<FileInformation>(info);

            infoFile.OriginalName = file.FileName.Split(".")[0];
            infoFile.Extension = file.FileName.Split(".")[1];

            var fileId = await _dataService.SaveFileInfo(infoFile);

            var marketDataList = _dataService.ReadFile(file, infoFile.Extension, fileId);

            await _dataService.SaveFileInfo(marketDataList);

            return Ok(new { message = "File has been successfully saved" });
        }
    }
}