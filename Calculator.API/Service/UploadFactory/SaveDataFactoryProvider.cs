using System;
using Calculator.API.Service.UploadFactory.Interfaces;

namespace Calculator.API.Service.UploadFactory
{
    public static class SaveDataFactoryProvider
    {
        public static ISaveData CreateFactoryFor(string ext)
        {
            ISaveData instance;

            switch (ext.ToUpper())
            {
                case "XLSX":
                case "XLS":
                case "CSV":
                    instance = (ISaveData)Activator.CreateInstance(typeof(SaveDataExcel));
                    break;
                case "JSON":
                    instance = (ISaveData)Activator.CreateInstance(typeof(SaveDataJSON));
                    break;
                default:
                    instance = null;
                    break;
            }

            return instance;
        }
    }
}