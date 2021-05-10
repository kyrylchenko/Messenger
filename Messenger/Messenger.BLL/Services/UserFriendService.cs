using AutoMapper;
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
  public  class UserFriendService
    {
        IRepository<UserFriend> UserFriendRepository { set; get; }
        public UserFriendService()
        {
            UserFriendRepository = new UserFriendRepository(new MessengerContext());
         
        }
        public UserFriendDTO Get(int id) =>
            DTOMapper.MapperFromEFObjectToDTO.
            Map<UserFriendDTO>(UserFriendRepository.Get(id));
        public IEnumerable<UserFriendDTO> GetAll() =>
            DTOMapper.MapperFromEFObjectToDTO.Map<ICollection<UserFriendDTO>>(UserFriendRepository.GetAll());

        public void Remove(UserFriendDTO entity) =>
            UserFriendRepository.Delete(DTOMapper.MapperFromDTOToEFObject.Map<UserFriend>(entity));
        public void UpdeteOrCreate(UserFriendDTO entity) =>
            UserFriendRepository.UpdateOrCreate(DTOMapper.MapperFromDTOToEFObject.Map<UserFriend>(entity));
        public void SaveChanges() =>
            UserFriendRepository.SaveChanges();
     
    }
}
