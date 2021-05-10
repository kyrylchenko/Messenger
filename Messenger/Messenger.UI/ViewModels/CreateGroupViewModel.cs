using Messenger.BLL.DTO;
using Messenger.UI.Infrastructure;
using Messenger.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Messenger.UI.ViewModels
{
    class CreateGroupViewModel:BaseNotifyPropertyChanged
    {

        public ObservableCollection<UserModel> UserFriends { get; set; } = new ObservableCollection<UserModel>();
        string groupName;
        public string GroupName 
            {
            get
            {
            return groupName;
            }
    set
        {
                groupName = value;
                Notify();
        }
            }
        string groupDescription;
        public string GroupDescription
        {
            get
            {
                return groupDescription;
            }
            set
            {
                groupDescription = value;
                Notify();
            }
        }

        public ICommand CreateGroupCommand { set; get; }
        public ICommand CancleCommand { set; get; }

        public CreateGroupViewModel()
        {
            InitializeCommands();
            foreach (var chatDTO in NetworkManager.Client.GetChats(NetworkManager.CurrentUser))
                foreach (var chatUserDTO in NetworkManager.Client.GetChatUsers(chatDTO))
                    if (UserFriends.FirstOrDefault((u) => u.User.UserId == chatUserDTO.UserId) == null && chatUserDTO.UserId != NetworkManager.CurrentUser.UserId)
                        UserFriends.Add(new UserModel() { User = NetworkManager.Client.GetUser(chatUserDTO.UserId) });
         
        }
        void InitializeCommands()
        {
            CreateGroupCommand = new RelayCommand(param =>
            {

                Window currentWindow = (Window)param;
                List<ChatUserDTO> chatUsers = new List<ChatUserDTO>();
                foreach (UserModel userModel in UserFriends.Where(um=>um.IsSelected))
                {
                    chatUsers.Add(new ChatUserDTO()
                    {

                        IsAdmin = false
                        ,
                        IsCreator = false
                        ,
                        UserId = userModel.User.UserId

                    }


                        );
                }
                chatUsers.Add(new ChatUserDTO()
                {
                    IsAdmin = true,
                    IsCreator = true,
                    UserId = NetworkManager.CurrentUser.UserId
                });


                NetworkManager.Client.CreateChat(new ChatDTO() { Name =GroupName, Description = GroupDescription }, chatUsers);
                currentWindow.DialogResult = true;
                currentWindow.Close();
               
            });
            CancleCommand = new RelayCommand(param =>
            {
                Window currentWindow = (Window)param;
             currentWindow.DialogResult = false;
                currentWindow.Close();

            });
        }
      

     
    }
}
