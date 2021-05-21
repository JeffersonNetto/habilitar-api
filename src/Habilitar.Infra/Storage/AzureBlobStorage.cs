using Habilitar.Core.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public class AzureBlobStorage : IAzureBlobStorage
    {
        private readonly StorageConfig _storageConfig;

        public AzureBlobStorage(StorageConfig storageConfig) =>
            _storageConfig = storageConfig;

        public async Task<string> Upload(string file, string nameFile)
        {
            var url = await UploadFileToStorage(file, nameFile, _storageConfig);

            return url;
        }

        private async Task<string> UploadFileToStorage(
            string fileBase64,
            string fileName,
            StorageConfig storageConfig)
        {
            var storageCredentials = new StorageCredentials(storageConfig.AccountName, storageConfig.AccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(storageConfig.ImageContainer);
            var blockBlob = container.GetBlockBlobReference(fileName);

            using var ms = new MemoryStream(Convert.FromBase64String(fileBase64));

            await blockBlob.UploadFromStreamAsync(ms);

            return blockBlob.SnapshotQualifiedStorageUri.PrimaryUri.ToString();
        }
    }
}
