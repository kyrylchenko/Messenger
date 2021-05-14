using Messenger.BLL.DTO;
using Messenger.UI.Infrastructure;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Messenger.UI.ViewModels
{
    class CreateOrEditUserViewModel:BaseNotifyPropertyChanged
    {
       
        public ICommand CreateOrEditUserCommand { set; get; }
        public ICommand CancleCommand { set; get; }
        public ICommand UploadUserPhotoCommand { set; get; }
        Bitmap userPhoto;
        public Bitmap UserPhoto
        
        {
            get
            {
                return userPhoto;
            }
            set
            {
                userPhoto = value;
                Notify();
            }
        }

        UserDTO user;
        public UserDTO User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                Notify();
            }
        }
        public CreateOrEditUserViewModel()
        {
            User = new UserDTO();
           InitializeCommands();
        }
        void InitializeCommands()
        {
            CancleCommand = new RelayCommand(param =>
            {
                Window currentWindow = param as Window;
                currentWindow.DialogResult = false;
                currentWindow.Close();
            });
            CreateOrEditUserCommand = new RelayCommand(param =>
            {
                NetworkManager.Client.Registration(User);
               
                Window currentWindow = param as Window;
                currentWindow.DialogResult = true;
                currentWindow.Close();

            });
            UploadUserPhotoCommand = new RelayCommand(param =>
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == true)
                {
                    using (FileStream fileStream = File.OpenRead(dlg.FileName))
                    {
                        try
                        {
                            User.Photo = NetworkManager.Client.UploadFile(System.IO.Path.GetFileName(dlg.FileName), fileStream).FileId;
                            fileStream.Position = 0;
                            UserPhoto = new Bitmap(fileStream);
                        }
                        catch (Exception excep)
                        {
                            MessageBox.Show(excep.Message);
                        }

                    }
                }
            });
        }
    

    

       
    }
}
