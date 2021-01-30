using System.Collections.Generic;
using System.Threading.Tasks;
using Calculator.API.Models;
using Microsoft.AspNetCore.Http;

namespace Calculator.API.Service.Interfaces
{
    public interface IDataService
    {
        IEnumerable<MarketData> ReadFile(IFormFile file, string ext, int fileId);
        Task<int> SaveFileInfo(FileInformation info);
        Task SaveFileInfo(IEnumerable<MarketData> marketDataList);
        Task<IEnumerable<FileFromDb>> RetrieveFiles(int start, int size);
        Task DeleteFile(int fileId);
    }
}