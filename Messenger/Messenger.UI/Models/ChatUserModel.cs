using Messenger.BLL.DTO;
using Messenger.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.UI.Models
{
    public class ChatUserModel:BaseNotifyPropertyChanged
    {
        ChatUserDTO chatUser;
        public ChatUserDTO ChatUser { 
            set
            {
                chatUser = value;
                Notify();
            }
            get
            {
                return chatUser;
            }
        }
        UserModel user;
        public UserModel User {  
        
            set
            {
                user = value;
                Notify();
            }
            get
            {
                return user;
            }
        }
      


    }
}
