using System.IO;
using System.Threading.Tasks;
using Calculator.API.Service.UploadFactory.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Calculator.API.Service.UploadFactory
{
    public class SaveDataExcel : ISaveData
    {
        public async Task SaveData(IFormFile file, int fileId)
        {
            await Task.Delay(1000);

        
        }
    }
}