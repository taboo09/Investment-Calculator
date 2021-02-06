using System.Linq;
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
    public class FilesController : ControllerBase
    {
        private readonly IDataService _dataService;

        public FilesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromForm] string info)
        {
            if (file == null || file.Length == 0) return BadRequest("File cannot be empty!");

            var infoFile = JsonConvert.DeserializeObject<FileInformation>(info);

            infoFile.OriginalName = file.FileName.Split(".")[0];
            infoFile.Extension = file.FileName.Split(".")[1];

            var fileId = await _dataService.SaveFileInfo(infoFile);

            var marketDataList = _dataService.ReadFile(file, infoFile.Extension, fileId);

            marketDataList = _dataService.SetMarketVariation(marketDataList.ToList());

            await _dataService.SaveFileInfo(marketDataList);

            return Ok(new { message = "File has been successfully saved" });
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles(int size, int start)
        {
            var newPaginationValues = Validate(size, start);

            var files = await _dataService.RetrieveFiles(newPaginationValues.Item2, newPaginationValues.Item1);

            return Ok(files);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFile(int fileId)
        {
            await _dataService.DeleteFile(fileId);

            return Ok(new { message = "File and its data has been successfully removed." });
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetFileData(int fileId)
        {
            var fileData = await _dataService.RetrieveFileData(fileId);

            return Ok(fileData);
        }

        private (int, int) Validate(int size, int start)
        {
            // size cannot be greater than 10 or less than 5
            size = size < 5 ? 5 : size > 10 ? 10 : size;

            // start cannot be less than 0
            start = start < 0 ? 0 : start;

            return (size, start);
        }
    }
}