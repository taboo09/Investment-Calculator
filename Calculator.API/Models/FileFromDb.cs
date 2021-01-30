using System;

namespace Calculator.API.Models
{
    public class FileFromDb
    {
        public int FileId { get; set; }
        public string Filename { get; set; }
        public string Market { get; set; }
        public int PeriodYears { get; set; }
        public string Fileinfo { get; set; }
        public string Extension { get; set; }
        private string CreatedAt;

        public DateTimeOffset Date
        {
            get { 
                return DateTimeOffset.Parse(CreatedAt); 
                }
        }
        
    }
}