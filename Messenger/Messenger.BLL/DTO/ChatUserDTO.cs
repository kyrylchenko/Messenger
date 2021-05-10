using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.DTO
{
    public class ChatUserDTO
    {
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public bool IsCreator { get; set; }
        public bool IsAdmin { get; set; }
    }
}
