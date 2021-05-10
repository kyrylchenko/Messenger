using Messenger.BLL.DTO;
using Messenger.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.UI.Models
{
   public class MessageModel:BaseNotifyPropertyChanged
    {
        MessageDTO message;
        public MessageDTO Message
        {
            set
            {
                message = value;
                Notify();
            }
            get
            {
                return message;
            }
        }
        UserModel sender;
        public UserModel Sender
        {
            set
            {
                sender = value;
                Notify();
            }
            get
            {
                return sender;
            }
        }

    }
}
