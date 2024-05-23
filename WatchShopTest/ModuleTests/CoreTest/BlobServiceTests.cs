using Azure.Storage.Blobs;
using Moq;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class BlobServiceTests
    {
        [Fact]
        public async Task GetBlob_ReturnsBlobUri()
        {
            // Arrange
            string blobName = "testBlob";
            string containerName = "testContainer";
            string expectedUri = "https://example.blob.core.windows.net/testContainer/testBlob";

            var blobServiceClientMock = new Mock<BlobServiceClient>();
            var blobContainerClientMock = new Mock<BlobContainerClient>();
            var blobClientMock = new Mock<BlobClient>();

            blobServiceClientMock.Setup(x => x.GetBlobContainerClient(containerName))
                .Returns(blobContainerClientMock.Object);
            blobContainerClientMock.Setup(x => x.GetBlobClient(blobName))
                .Returns(blobClientMock.Object);
            blobClientMock.Setup(x => x.Uri).Returns(new Uri(expectedUri));

            var blobService = new BlobService(blobServiceClientMock.Object);

            // Act
            var result = await blobService.GetBlob(blobName, containerName);

            // Assert
            Assert.Equal(expectedUri, result);
        }
    }
}
