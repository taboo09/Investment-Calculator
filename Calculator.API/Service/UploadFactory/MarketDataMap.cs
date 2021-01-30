using Calculator.API.Models;
using CsvHelper.Configuration;

namespace Calculator.API.Service.UploadFactory
{
    public sealed class MarketDataMap: ClassMap<MarketData> {  
        public MarketDataMap() {  
            Map(x => x.Price).Name("Close");  
            Map(x => x.Date).Name("Date");
        }  
    }  
}