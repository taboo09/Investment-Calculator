using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Calculator.API.Service.UploadFactory.Interfaces
{
    public interface ISaveData
    {
        Task SaveData(IFormFile file, int fileId);
    }
}