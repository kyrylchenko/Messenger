using Messenger.BLL.DTO;
using Messenger.UI.Infrastructure;
using Messenger.UI.MessengerService;
using Messenger.UI.Models;
using Messenger.UI.Views;
//using Messenger.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace Messenger.UI.ViewModels
{
   public class MainViewModel:BaseNotifyPropertyChanged,MessengerService.IMessengerServiceCallback
    {
       
        public ObservableCollection<ChatModel> UserChats
            {
            set;
            get;
            }
        ChatModel selectedChat;
        public ChatModel SelectedChat
        {
            get
            {
                return selectedChat;
            }
            set
            {
                selectedChat = value;
                Notify();
            }
        }
       
        public ICommand SendMessageCommand { set; get; }
        public ICommand DisconnectCommand
        { set; get; }
        public ICommand AddContactCommand
        { set; get; }
        public ICommand CreateChatCommand
        { set; get; }
        public ICommand OutCommand
        { set; get; }


    
     

        public MainViewModel()
        {
            NetworkManager.Client = new MessengerService.MessengerServiceClient(new System.ServiceModel.InstanceContext(this));      
            Application.Current.MainWindow.Effect = new BlurEffect();
            
            if (new LoginView().ShowDialog() != true)
                Application.Current.MainWindow.Close();
            Application.Current.MainWindow.Effect = null;
            InitializeCommands();
            InitializeUserChats();
        }
        void InitializeUserChats()
        {
            UserChats = new ObservableCollection<ChatModel>();
            foreach(var chat in NetworkManager.Client.GetChats(NetworkManager.CurrentUser))
              UserChats.Add(InitializeChat(chat));
        }
        ChatModel InitializeChat(ChatDTO chat)
        {
            ChatModel chatModel = new ChatModel();
            chatModel.Chat = chat;
            chatModel.DraftMessage = new MessageDTO();
          
            foreach (var chatUser in NetworkManager.Client.GetChatUsers(chat))
            {
              
                ChatUserModel chatUserModel = new ChatUserModel() { ChatUser = chatUser };
                chatUserModel.User = new UserModel() { User = NetworkManager.Client.GetUser(chatUser.UserId) };
                //if(chatUserModel.User.User.Photo != null)
                //{
                //    Stream photoStream ;
                //    int photoId = (int)chatUserModel.User.User.Photo;
                //    string downloadingFileName = Client.DownloadFile(ref photoId, out photoStream);
                //    string downloadingFilePath = Path.Combine(fileDirectoryPath, downloadingFileName);
                //    //if (!File.Exists(downloadingFilePath))
                //    //{
                //    //    using(FileStream savingFileStream = new FileStream(downloadingFilePath,FileMode.Create))
                //    //    {
                //    //        photoStream.Seek(0, SeekOrigin.Begin);
                //    //        photoStream.CopyTo(savingFileStream);
                //    //    }
                //    //} 
                //    chatUserModel.User.UserPhoto = new System.Drawing.Bitmap(downloadingFilePath);
                //}
                chatModel.Members.Add(chatUserModel);



            }
            if (chatModel.Chat.IsPrivateChat)
                chatModel.Chat.Name = chatModel.Members.FirstOrDefault((chatUserModel) => chatUserModel.User.User.UserId != NetworkManager.CurrentUser.UserId).User.User.Name;
            foreach (var msg in NetworkManager.Client.GetMessages(chat))
                chatModel.Messages.Add(new MessageModel() { Message = msg, Sender = chatModel.Members.FirstOrDefault((chatMembers)=>chatMembers.User.User.UserId == msg.SenderId).User });
            return chatModel;
        }
      void  InitializeCommands()
        {
            SendMessageCommand = new RelayCommand((param) =>
            {
                SelectedChat.DraftMessage.ChatId = SelectedChat.Chat.ChatId;
                SelectedChat.DraftMessage.SenderId = NetworkManager.CurrentUser.UserId;
                SelectedChat.DraftMessage.SendTime = DateTime.Now;
                SelectedChat.DraftMessage.MessageType = MessageType.Text;
                NetworkManager.Client.SendMessage(SelectedChat.DraftMessage);
                SelectedChat.Messages.Add(new MessageModel() { Message = SelectedChat.DraftMessage });
                SelectedChat.DraftMessage = new MessageDTO();
            });
            DisconnectCommand = new RelayCommand((param) =>
            {
                if (NetworkManager.Client.State == System.ServiceModel.CommunicationState.Opened)
                {
                    NetworkManager.Client.Disconnect(NetworkManager.CurrentUser);
                    MessageBox.Show("Dis");
                }
            });
            AddContactCommand = new RelayCommand((param) =>
            {
                
                    AddContactView addContactView = new AddContactView(NetworkManager.Client, NetworkManager.CurrentUser)
                    {
                        WindowStartupLocation = WindowStartupLocation.CenterOwner
                    ,
                        Owner = Application.Current.MainWindow
                    };
                    Application.Current.MainWindow.Effect = new BlurEffect();
                    addContactView.ShowDialog();
                    Application.Current.MainWindow.Effect = null;
               
            });
            CreateChatCommand = new RelayCommand((param) =>
            {

                CreateGroupView createGroupView = new CreateGroupView()
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                ,
                    Owner = Application.Current.MainWindow
                };
                Application.Current.MainWindow.Effect = new BlurEffect();
                createGroupView.ShowDialog();
                Application.Current.MainWindow.Effect = null;

            });
        }
       

        public  void CallBackMsg(MessageDTO msg)
        {
            App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                Thread.Sleep(20);
                ChatModel currentChat = UserChats.FirstOrDefault((chat) => chat.Chat.ChatId == msg.ChatId);
                currentChat.Messages.Add(
                    new MessageModel() 
                    { Message = msg
                    , Sender = currentChat.Members.FirstOrDefault((user)
                    => user.User.User.UserId == msg.SenderId).User });
            });
           


        }

        public void CallBackChatAdded(ChatDTO chat)
        {
           
          App.Current.Dispatcher.BeginInvoke((Action)delegate ()
          {
              Thread.Sleep(20);
              UserChats.Add(InitializeChat(chat));
          });
               
            
        }
    }
}
