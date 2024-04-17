using WatchShop_Core.Models.Brends.Request;
using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.Models.Comments.Request;
using WatchShop_Core.Models.Comments.Response;
using WatchShop_Core.Models.Orders.Request;
using WatchShop_Core.Models.Orders.Response;
using WatchShop_Core.Models.Watches.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface ICommentService
    {
        Task<CommentModel> CreateCommentAsync(CreateCommentModel model);

        Task<IEnumerable<CommentModel>> GetAllCommentsAsync();

        Task DeleteCommentAsync(Guid id);

        Task<CommentModel> UpdateCommentAsync(Guid id, UpdateCommentModel model);

        Task<IEnumerable<CommentModel>> GetCommentsByUserNameAsync(string username);

        Task<IEnumerable<CommentModel>> GetCommentsByWatchNameModelAsync(string nameModel);

        Task<CommentModel> GetCommentByIdAsync(Guid id);
    }
}
