using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Calculator.API.Models;
using Calculator.API.Service.UploadFactory.Interfaces;
using CsvHelper;
using Microsoft.AspNetCore.Http;

namespace Calculator.API.Service.UploadFactory
{
    public class ReadDataCSV : ISaveData
    {
        public IEnumerable<MarketData> ReadData(IFormFile file, int fileId)
        {
            IEnumerable<MarketData> marketDataList;

            using (var stream = file.OpenReadStream())
            {
                try
                {
                    TextReader reader = new StreamReader(stream);
                    
                    var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                    csvReader.Context.RegisterClassMap<MarketDataMap>();

                    marketDataList = csvReader.GetRecords<MarketData>().ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
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
}