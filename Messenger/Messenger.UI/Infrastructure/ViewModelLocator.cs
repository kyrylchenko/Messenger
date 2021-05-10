using Messenger.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.UI.Infrastructure
{
     class ViewModelLocator
    {
        public ViewModelLocator()
        {

        }
        public AddContactViewModel AddContactViewModel { get => new AddContactViewModel(); }
        public CreateGroupViewModel CreateGroupViewModel { get => new CreateGroupViewModel(); }

     
        public LoginViewModel LoginViewModel { get => new LoginViewModel(); }
        public MainViewModel MainViewModel { get => new MainViewModel(); }
     
        public CreateOrEditUserViewModel CreateOrEditUserViewModel { get => new CreateOrEditUserViewModel(); }





    }
}
