using System;

namespace Calculator.API.Models
{
    public class MarketData
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}