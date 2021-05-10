using Messenger.BLL.DTO;
using Messenger.BLL.MapperDTO;
using Messenger.DAL.EFContext;
using Messenger.DAL.Infrastucture;
using Messenger.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.Services
{
    public class ChatService
    {
        IRepository<Chat> ChatRepository { set; get; }
        public ChatService()
        {
            ChatRepository = new ChatRepository(new MessengerContext());

        }
        public ChatDTO Get(int id) =>
            DTOMapper.MapperFromEFObjectToDTO.
            Map<ChatDTO>(ChatRepository.Get(id));
        public IEnumerable<ChatDTO> GetAll() =>
            DTOMapper.MapperFromEFObjectToDTO.Map<ICollection<ChatDTO>>(ChatRepository.GetAll());

        public void Remove(ChatDTO entity) =>
            ChatRepository.Delete(DTOMapper.MapperFromDTOToEFObject.Map<Chat>(entity));
        public void UpdeteOrCreate(ChatDTO entity) =>
            ChatRepository.UpdateOrCreate(DTOMapper.MapperFromDTOToEFObject.Map<Chat>(entity));
        public void SaveChanges() =>
            ChatRepository.SaveChanges();
    }
}
