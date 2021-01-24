using System;

namespace Calculator.API.Models
{
    public class FileInformation
    {
        public FileInformation()
        {
            CreatedAt = DateTimeOffset.Now;
        }

        public string Filename { get; set; }
        public string Market { get; set; }
        public int Period { get; set; }
        public string Fileinfo { get; set; }
        public string Extension { get; set; }
        public string OriginalName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}