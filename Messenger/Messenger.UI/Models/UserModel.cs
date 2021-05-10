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
    public class UserModel:BaseNotifyPropertyChanged
    {
        UserDTO user;
        public UserDTO User
        {
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

        Bitmap userPhoto;
            public Bitmap UserPhoto
        {
            set
            {
                userPhoto = value;
                Notify();
            }
            get
            {
                return userPhoto;
            }
        }
        bool isSelected;
        public bool IsSelected
        {
            set
            {
                isSelected = value;
                Notify();

            }
            get
            {
                return isSelected;
            }
        }


      
    }
}
