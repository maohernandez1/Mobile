using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Accesories.Common.Models
{
    public class PhotoModel : TableEntity, IBaseModel
    {
        public PhotoModel(string partitionKey, string rowKey)
        {
            RowKey = rowKey;
            PartitionKey = partitionKey;
        }
        public PhotoModel() { }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
