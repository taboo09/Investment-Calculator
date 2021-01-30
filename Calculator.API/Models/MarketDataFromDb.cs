using System;

namespace Calculator.API.Models
{
    public class MarketDataFromDb
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}