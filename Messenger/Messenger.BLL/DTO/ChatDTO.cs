using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.DTO
{
    public class ChatDTO
    {
        public ChatDTO()
        {
        }

        public int ChatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsPrivateChat { get; set; }
    }
}
