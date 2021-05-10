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
    public class MessageService
    {
        IRepository<Message> MessageRepository { set; get; }
        public MessageService()
        {
            MessageRepository = new MessageRepository(new MessengerContext());

        }
        public MessageDTO Get(int id) =>
            DTOMapper.MapperFromEFObjectToDTO.
            Map<MessageDTO>(MessageRepository.Get(id));
        public IEnumerable<MessageDTO> GetAll() =>
            DTOMapper.MapperFromEFObjectToDTO.Map<ICollection<MessageDTO>>(MessageRepository.GetAll());

        public void Remove(MessageDTO entity) =>
            MessageRepository.Delete(DTOMapper.MapperFromDTOToEFObject.Map<Message>(entity));
        public void UpdeteOrCreate(MessageDTO entity) =>
            MessageRepository.UpdateOrCreate(DTOMapper.MapperFromDTOToEFObject.Map<Message>(entity));
        public void SaveChanges() =>
            MessageRepository.SaveChanges();
    }
}
