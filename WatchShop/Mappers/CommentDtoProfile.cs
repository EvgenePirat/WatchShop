using AutoMapper;
using WatchShop_Core.Models.Comments.Request;
using WatchShop_Core.Models.Comments.Response;
using WatchShop_UI.Dtos.Comments.Request;
using WatchShop_UI.Dtos.Comments.Response;

namespace WatchShop_UI.Mappers
{
    public class CommentDtoProfile : Profile
    {
        public CommentDtoProfile()
        {
            CreateMap<CreateCommentDto, CreateCommentModel>();
            CreateMap<UpdateCommentDto, UpdateCommentModel>();
            CreateMap<CommentModel, CommentDto>();
        }
    }
}
