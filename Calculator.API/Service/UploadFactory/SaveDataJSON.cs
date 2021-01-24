using System.IO;
using System.Threading.Tasks;
using Calculator.API.Service.UploadFactory.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Calculator.API.Service.UploadFactory
{
    public class SaveDataJSON : ISaveData
    {
        public async Task SaveData(IFormFile file, int fileId)
        {
            await Task.Delay(1000);
            
            throw new System.NotImplementedException();
        }
    }
}