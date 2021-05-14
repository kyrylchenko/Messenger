using Messenger.UI.Infrastructure;
using Messenger.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Messenger.UI.ViewModels
{
    class LoginViewModel:BaseNotifyPropertyChanged
    {
       public ICommand LoginCommand { set; get; }
        public ICommand CancleCommand { set; get; }
        public ICommand OpenRegistrationViewCommand { set; get; }
        string userLogin;
        string userPassword;
        public string UserLogin
        {
            get
            {
                return userLogin;
            }
            set
            {
                userLogin = value;
                Notify();
            }
        }
        public string UserPassword
        {
            get
            {
                return userPassword;
            }
            set
            {
                userPassword = value;
                Notify();
            }
        }


        public LoginViewModel()
        {
            InitializeCommands();
        }
      void InitializeCommands()
        {
            LoginCommand = new RelayCommand(async param =>
             {
                 try
                 {
                    NetworkManager.CurrentUser = await NetworkManager.Client.ConnectAsync(UserLogin,UserPassword);

                     Window currentWindow = param as Window;
                     currentWindow.DialogResult = true;
                     currentWindow.Close();

                 }
                 catch (Exception excep)
                 {
                     new MessageBoxView(excep.Message).Show();
                 }
                
             });
           OpenRegistrationViewCommand = new RelayCommand( param =>
           {
               try
               {
                   Window currentWindow = param as Window;
                   
                   RegistrationView registrationView = new RegistrationView() { WindowStartupLocation = WindowStartupLocation.CenterOwner, Owner =currentWindow };;
                   registrationView.ShowDialog();
               }
               catch (Exception excep)
               {
                   new MessageBoxView(excep.Message).Show();
               }

           });
            CancleCommand = new RelayCommand(param =>
            {
                Window currentWindow = param as Window;
                currentWindow.DialogResult = false;
                currentWindow.Close();
            });
        }

      

       
    }
}
