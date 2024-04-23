using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Messages.Request;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly TelegramBotClient botClient;
        private readonly string channelId;
        private readonly IConfiguration _configuration;

        public MessageService(IConfiguration configuration)
        {
            _configuration = configuration;
            botClient = new TelegramBotClient(_configuration["TelegramSettings:TokenBot"]);
            channelId = _configuration["TelegramSettings:ChannelId"];
        }

        public async Task<bool> SentMessageTelegramAsync(PostMessageModel model)
        {
            string messageText = model.ToString();

            try
            {
                await botClient.SendTextMessageAsync(channelId, messageText);

                return true;
            }
            catch (Exception ex)
            {
                throw new MessageArgumentException(ex.Message);
            }
        }
    }
}
