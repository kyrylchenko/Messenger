using AutoMapper;
using Messenger.BLL.DTO;
using Messenger.DAL.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.MapperDTO
{
   static class DTOMapper
    {
        public static IMapper MapperFromDTOToEFObject { private set; get; }
            = new Mapper(new MapperConfiguration((cfg) =>
            {


                cfg.CreateMap<ChatDTO, Chat>();
                cfg.CreateMap<ChatUserDTO, ChatUser>();
                cfg.CreateMap<FileDTO, File>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<UserFriendDTO, UserFriend>();
                cfg.CreateMap<MessageDTO, Message>()
               .ForMember("MessageType",
               opt =>
               opt.MapFrom(src => src.MessageType.ToString()));


            }));
        public static IMapper MapperFromEFObjectToDTO { private set; get; }
           = new Mapper(new MapperConfiguration((cfg) =>
           {
               cfg.CreateMap<Chat, ChatDTO>();
               cfg.CreateMap<ChatUser, ChatUserDTO>();
               cfg.CreateMap<File, FileDTO>();
               cfg.CreateMap<User, UserDTO>();
               cfg.CreateMap<UserFriend, UserFriendDTO>();
               cfg.CreateMap<Message, MessageDTO>()
             .ForMember("MessageType", opt =>
             opt.MapFrom(src => Enum.Parse(typeof(MessageType), src.MessageType)));

           }));
  

    }
}
