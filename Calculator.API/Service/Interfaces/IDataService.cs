using System.Threading.Tasks;
using Calculator.API.Models;
using Microsoft.AspNetCore.Http;

namespace Calculator.API.Service.Interfaces
{
    public interface IDataService
    {
        Task SaveFile(IFormFile file, string ext, int fileId);
        Task<int> SaveFileInfo(FileInformation info);
    }
}