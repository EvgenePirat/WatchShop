using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using WatchShop_Core.Exceptions;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class BlobService : IBlobService
    {

        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<bool> DeleteBlobAsync(string blobName, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

            return await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> UploadBlob(string blobName, string containerName, IFormFile file)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            if(result != null)
            {
                return await GetBlob(blobName, containerName);
            }
            else
            {
                throw new ImageArgumentException("Error with save photo");
            }
        }

        public async Task<string> GetBlob(string blobName, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
