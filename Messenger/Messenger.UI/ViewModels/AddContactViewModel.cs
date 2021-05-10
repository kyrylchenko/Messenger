using Messenger.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Messenger.UI.Views;

namespace Messenger.UI.ViewModels
{
    class AddContactViewModel
    {
        public string AddingUserLogin { set; get; }
        public ICommand AddContactCommand { set; get; }
        public ICommand  CancleCommand { set; get; } 
        public AddContactViewModel()
        {
            InitializeCommands();
        }
        void InitializeCommands()
        {
            AddContactCommand = new RelayCommand(async param =>
            {
                try
                {
                    Window currentWindow = param as Window;
                    await NetworkManager.Client.AddContactAsync(AddingUserLogin, NetworkManager.CurrentUser);

                    currentWindow.DialogResult = true;
                    currentWindow.Close();
                }
                catch (Exception excep)
                {
                    new MessageBoxView(excep.Message).ShowDialog();
                }
            });
            CancleCommand  = new RelayCommand(param =>
                {
                    Window currentWindow = param as Window;
                    currentWindow.DialogResult = false;
                    currentWindow.Close();
                });
        }

       
    }
}
