using Messenger.BLL.DTO;
using Messenger.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.UI.Models
{
    public class ChatModel : BaseNotifyPropertyChanged
    {
        ObservableCollection<MessageModel> messages;
        public ObservableCollection<MessageModel> Messages
        {
            set
            {
                messages = value;
                Notify();
            }
            get
            {
                return messages;
            }
        }
        ObservableCollection<ChatUserModel> members;
        public ObservableCollection<ChatUserModel> Members
        {
            set
            {
                members = value;
                Notify();
            }
            get
            {
                return members;
            }
        }
        public Bitmap chatPhoto;
        public Bitmap ChatPhoto { 
            set
            {
                chatPhoto = value;
                Notify();
            }
            get
            {
                return chatPhoto;
            }
        }
        public ChatDTO  Chat {get;set;}
        MessageDTO draftMessage;
        public MessageDTO DraftMessage
        {
            set
            {
                draftMessage = value;
                Notify();
            }
            get
            {
                return draftMessage;
            }
        }
        int countUnreadMessages;
        public int CountUnreadMessages
        {
            set
            {
                countUnreadMessages = value;
                Notify();
            }
            get
            {

                return countUnreadMessages;
             }
        }
        public MessageDTO LastMessage
        { 
          
            get
            {
                return Messages?[0].Message;
            }
        }
        public ChatModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Members = new ObservableCollection<ChatUserModel>();
            Messages.CollectionChanged += (sender,e) =>
              {
                  Notify("LastMessage");
              };
        }



    }
}
