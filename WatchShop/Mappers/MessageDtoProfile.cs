using AutoMapper;
using WatchShop_Core.Models.Messages.Request;
using WatchShop_UI.Dtos.Messages.Request;

namespace WatchShop_UI.Mappers
{
    public class MessageDtoProfile : Profile
    {
        public MessageDtoProfile()
        {
            CreateMap<PostMessageDto, PostMessageModel>();
        }
    }
}
