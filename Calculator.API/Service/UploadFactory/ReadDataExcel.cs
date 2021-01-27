using Calculator.API.Models;
using Calculator.API.Service.UploadFactory.Interfaces;
using Ganss.Excel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Ganss.Excel.Exceptions;
using System;

namespace Calculator.API.Service.UploadFactory
{
    public class ReadDataExcel : ISaveData
    {        
        public IEnumerable<MarketData> ReadData(IFormFile file, int fileId)
        {
            var marketDataList = new List<MarketData>();

            using (var stream = file.OpenReadStream())
            {
                try
                {
                    var data = new ExcelMapper(stream) 
                    {
                        HeaderRow = true,
                        SkipBlankRows = true
                    };

                    data.AddMapping<MarketData>("Date", p => p.Date);
                    data.AddMapping<MarketData>("Close", p => p.Price);

                    marketDataList = data.Fetch<MarketData>()
                        .Select(x => 
                            { 
                                x.FileId = fileId;
                                x.Price = Math.Round(x.Price, 2);
                                return x;
                            })
                        .ToList();
                }
                catch (ExcelMapperConvertException ex)
                {
                    throw new ExcelMapperConvertException(ex.Message);
                }
                
                return marketDataList;
            }
        }
    }
}