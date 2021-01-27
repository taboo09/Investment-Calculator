using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Calculator.API.Models;
using Calculator.API.Service.UploadFactory.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Calculator.API.Service.UploadFactory
{
    public class ReadDataJSON : ISaveData
    {
        public IEnumerable<MarketData> ReadData(IFormFile file, int fileId)
        {
            var marketDataList = new List<MarketData>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var fileContent = reader.ReadToEnd();

                marketDataList = JsonConvert.DeserializeObject<List<MarketData>>(fileContent);
            }
            
            return marketDataList
                .Select(x => 
                    { 
                        x.FileId = fileId;
                        x.Price = Math.Round(x.Price, 2);
                        return x;
                    })
                .ToList();
        }
    }
}