using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calculator.API.Models;
using Calculator.API.Service.Interfaces;
using Calculator.API.Service.UploadFactory;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;

namespace Calculator.API.Service
{
    public class DataService : IDataService
    {
        private readonly string _connectionString;

        public DataService()
        {
            _connectionString = GetSettings.ConnectionString();
        }

        public async Task<int> SaveFileInfo(FileInformation info)
        {
            using var connection = new SqliteConnection(_connectionString);

            var sql_insert = @"INSERT INTO Files (FileName, FileInfo, Extension, Market, OriginalName, PeriodYears, CreatedAt)
                VALUES (@Filename, @Fileinfo, @Extension, @Market, @OriginalName, @Period, @CreatedAt);
                select last_insert_rowid()";
                
            try
            {
                return Convert.ToInt32(await connection.ExecuteScalarAsync(sql_insert, info));
            }
            catch (SqliteException)
            {
                throw new SqliteException("Database Error", 1);
            }
        }

        public IEnumerable<MarketData> ReadFile(IFormFile file, string ext, int fileId)
        {
            var saveDataInstance = SaveDataFactoryProvider.CreateFactoryFor(ext);

            if (saveDataInstance is null) 
                throw new ArgumentNullException($"File with extension {ext} can't be read. Please upload a file with an accepted extension.");

            return saveDataInstance.ReadData(file, fileId);
        }

        public IEnumerable<MarketData> SetMarketVariation(List<MarketData> marketDataList)
        {
            for (int i = 1; i < marketDataList.Count; i++)
            {
                var variation = Math.Round((marketDataList[i].Price - marketDataList[i - 1].Price) / marketDataList[i - 1].Price * 100, 2);

                marketDataList[i].Variation = variation;
            }

            marketDataList[0].Variation = 0;

            return marketDataList;
        }

        public async Task SaveFileInfo(IEnumerable<MarketData> marketDataList)
        {
            using var connection = new SqliteConnection(_connectionString);

            var sql_insert = @"INSERT INTO Market_Data (FileId, Date, Price, Variation)
                VALUES (@FileId, @Date, @Price, @Variation)";
            
            try
            {
                await connection.ExecuteAsync(sql_insert, marketDataList);
            }
            catch (SqliteException)
            {
                throw new SqliteException("Database Error", 1);
            }
        }

        public async Task<IEnumerable<FileFromDb>> RetrieveFiles(int start, int size)
        {
            IEnumerable<FileFromDb> files = new List<FileFromDb>();

            using var connection = new SqliteConnection(_connectionString);

            var sql = @"Select * From Files Limit @Size Offset @Start";

            try
            {
                files = await connection.QueryAsync<FileFromDb>(sql, new 
                { 
                    Size = size,
                    Start = start
                });
            }
            catch (SqliteException)
            {
                throw new SqliteException("Database Error", 1);
            }

            return files;
        }

        public async Task DeleteFile(int fileId)
        {
            using var connection = new SqliteConnection(_connectionString);

            var sql = @"Delete From Files Where FileId = @FileId";

            try
            {
                await connection.ExecuteAsync(sql, new { FileId = fileId });
            }
            catch (SqliteException)
            {
                throw new SqliteException("Database Error", 1);
            }
        }

        public async Task<IEnumerable<MarketDataFromDb>> RetrieveFileData(int fileId)
        {
            IEnumerable<MarketDataFromDb> marketDataList;

            using var connection = new SqliteConnection(_connectionString);

            var sql = @"Select Date, Price From Market_Data Where FileId = @FileId";

            try
            {
                marketDataList = await connection.QueryAsync<MarketDataFromDb>(sql, new { FileId = fileId });
            }
            catch (SqliteException)
            {
                throw new SqliteException("Database Error", 1);
            }

            return marketDataList;
        }
    }
}