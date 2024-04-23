using WatchShop_Core.Models.Messages.Request;

namespace WatchShop_Core.ServiceContracts
{
    public interface IMessageService
    {
        Task<bool> SentMessageTelegramAsync(PostMessageModel model);
    }
}
