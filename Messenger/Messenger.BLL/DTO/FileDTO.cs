using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.DTO
{
    public class FileDTO
    {
      
        public FileDTO()
        {
        }

        public int FileId { get; set; }
        public string FilePath { get; set; }
    }
}
