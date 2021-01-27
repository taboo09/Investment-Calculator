using System.Collections.Generic;
using System.Threading.Tasks;
using Calculator.API.Models;
using Microsoft.AspNetCore.Http;

namespace Calculator.API.Service.UploadFactory.Interfaces
{
    public interface ISaveData
    {
        IEnumerable<MarketData> ReadData(IFormFile file, int fileId);
    }
}