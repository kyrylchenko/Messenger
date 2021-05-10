using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Messenger.BLL.DTO;
using Messenger.BLL.MapperDTO;
using Messenger.DAL.EFContext;
using Messenger.DAL.Infrastucture;
using Messenger.DAL.Repositories;

namespace Messenger.BLL.Services
{
   public class UserService
    {
        IRepository<User> UserRepository { set; get; }


        public UserService()
        {
            UserRepository = new UserRepository(new MessengerContext());

        }
        public UserDTO Get(int id)
        {
       
            Console.WriteLine($"I get user with em :{DTOMapper.MapperFromEFObjectToDTO.Map<UserDTO>(UserRepository.Get(id)).Email}");
          return  DTOMapper.MapperFromEFObjectToDTO.
            Map<UserDTO>(UserRepository.Get(id));
        }
        public IEnumerable<UserDTO> GetAll() =>
            DTOMapper.MapperFromEFObjectToDTO.Map<ICollection<UserDTO>>(UserRepository.GetAll());

        public void Remove(UserDTO entity) =>
            UserRepository.Delete(DTOMapper.MapperFromDTOToEFObject.Map<User>(entity));
        public void UpdeteOrCreate(UserDTO entity) =>
            UserRepository.UpdateOrCreate(DTOMapper.MapperFromDTOToEFObject.Map<User>(entity));
        public void SaveChanges() =>
            UserRepository.SaveChanges();
    }
}
