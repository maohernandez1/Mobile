using Accesories.Common.Models;
using Accesories.Functions.Services.Base;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accesories.Functions.Services
{
    public abstract class PhotosTableStorageService : BaseTableStorageService
    {
        public static async Task<List<PhotoModel>> GetAllEntities(string tableName)
        {
            var table = GetTable(tableName);
            TableQuery<PhotoModel> query = new TableQuery<PhotoModel>();
            TableContinuationToken token = null;
            var entities = new List<PhotoModel>();
            try
            {
            do
            {
                var queryResult = await table.ExecuteQuerySegmentedAsync(query, token);
                entities.AddRange(queryResult.Results);
                token = queryResult.ContinuationToken;
            } while (token != null);


            }
            catch(Exception ex)
            {

            }
            return entities;
        }
    }
}
