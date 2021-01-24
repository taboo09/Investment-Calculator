using System.IO;
using Microsoft.Extensions.Configuration;

namespace Calculator.API.Service
{
    public static class GetConnectionString
    {
        public static string ConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connection = "";

            try
            {
                connection = configuration.GetConnectionString("db-connection");
            }
            catch (System.Exception)
            {
                throw new System.Exception("AppSettings.JSON couldn't been read");
            }
            
            return connection;
        }
    }
}