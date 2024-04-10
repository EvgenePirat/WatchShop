using Microsoft.AspNetCore.Http;

namespace WatchShop_Core.ServiceContracts
{
    public interface IBlobService
    {
        Task<string> GetBlob(string blobName, string containerName);
        Task<bool> DeleteBlobAsync(string blobName, string containerName);
        Task<string> UploadBlob(string blobName, string containerName, IFormFile file);
    }
}
