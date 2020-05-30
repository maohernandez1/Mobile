using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accesories.Functions.Services.Base
{
    public abstract class BaseTableStorageService : StorageAccountService
    {
        #region Constant Fields
        readonly static Lazy<CloudTableClient> _tableClientHolder = new Lazy<CloudTableClient>(_storageAccountHolder.Value.CreateCloudTableClient);
        #endregion


        public static CloudTable GetTable(string tableName)
        {
            CloudTable table = _tableClientHolder.Value.GetTableReference(tableName);
            return table;
        }
    }
}
