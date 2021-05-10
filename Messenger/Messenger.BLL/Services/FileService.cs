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
    public class FileService
    {
        IRepository<File> FileRepository { set; get; }
        public FileService()
        {
            FileRepository = new FileRepository(new MessengerContext());

        }
        public FileDTO Get(int id) =>
            DTOMapper.MapperFromEFObjectToDTO.
            Map<FileDTO>(FileRepository.Get(id));
        public IEnumerable<FileDTO> GetAll() =>
            DTOMapper.MapperFromEFObjectToDTO.Map<ICollection<FileDTO>>(FileRepository.GetAll());

        public void Remove(FileDTO entity) =>
            FileRepository.Delete(DTOMapper.MapperFromDTOToEFObject.Map<File>(entity));
        public void UpdeteOrCreate(FileDTO entity) =>
            FileRepository.UpdateOrCreate(DTOMapper.MapperFromDTOToEFObject.Map<File>(entity));
        public void SaveChanges() =>
            FileRepository.SaveChanges();
    }
}
