using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;
using Messenger.BLL.MapperDTO;
using Messenger.DAL.EFContext;
using Messenger.DAL.Infrastucture;
using Messenger.DAL.Repositories;

namespace Messenger.BLL.Services
{
    public class ChatUserService
    {
        IRepository<ChatUser> ChatUserRepository { set; get; }
        public ChatUserService()
        {
            ChatUserRepository = new ChatUserRepository(new MessengerContext());

        }
        public ChatUserDTO Get(int id) =>
            DTOMapper.MapperFromEFObjectToDTO.
            Map<ChatUserDTO>(ChatUserRepository.Get(id));
        public IEnumerable<ChatUserDTO> GetAll() =>
            DTOMapper.MapperFromEFObjectToDTO.Map<ICollection<ChatUserDTO>>(ChatUserRepository.GetAll());

        public void Remove(ChatUserDTO entity) =>
            ChatUserRepository.Delete(DTOMapper.MapperFromDTOToEFObject.Map<ChatUser>(entity));
        public void UpdeteOrCreate(ChatUserDTO entity) =>
            ChatUserRepository.UpdateOrCreate(DTOMapper.MapperFromDTOToEFObject.Map<ChatUser>(entity));
        public void SaveChanges() =>
            ChatUserRepository.SaveChanges();
    }
}
