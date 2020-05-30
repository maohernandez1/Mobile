using Accesories.Common.Models;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accesories.Functions.Services.Base
{
    public abstract class StorageAccountService
    {
        readonly static Lazy<string> _connectionStringHolder = new Lazy<string>(() => Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
        protected readonly static Lazy<CloudStorageAccount> _storageAccountHolder = new Lazy<CloudStorageAccount>(() => CloudStorageAccount.Parse(_connectionStringHolder.Value));
    }
}
