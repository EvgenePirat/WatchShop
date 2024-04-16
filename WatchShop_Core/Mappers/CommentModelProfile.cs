using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Comments.Request;
using WatchShop_Core.Models.Comments.Response;

namespace WatchShop_Core.Mappers
{
    public class CommentModelProfile : Profile
    {
        public CommentModelProfile()
        {
            CreateMap<CreateCommentModel, WatchComment>();
            CreateMap<UpdateCommentModel, WatchComment>();
            CreateMap<WatchComment, CommentModel>();
        }
    }
}
