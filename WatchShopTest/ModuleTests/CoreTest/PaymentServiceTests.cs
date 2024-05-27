using Moq;
using WatchShop_Core.Services;
using Microsoft.Extensions.Configuration;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class PaymentServiceTests
    {
        [Fact]
        public void MakePayment_ReturnsPaymentIntentModel()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(conf => conf["StripeSettings:SecretKey"])
                .Returns("sk_test_51P8294Jqil8qlI9LYxk6byFTQevXiuWDfxovlv3IC94ai1HvdpnaeThCxP7vAVptK0HJKimWHUGi3XyLjaDZgG2D00ALQuNAqP");

            var paymentService = new PaymentService(configurationMock.Object);
            var cartTotal = 100.0;

            // Act
            var result = paymentService.CreatePayment(cartTotal);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.StripePaymentIntentId);
            Assert.NotNull(result.ClientSecret);
            // Add more assertions as needed

            Assert.False(string.IsNullOrEmpty(result.StripePaymentIntentId));
            Assert.False(string.IsNullOrEmpty(result.ClientSecret));
        }
    }
}
