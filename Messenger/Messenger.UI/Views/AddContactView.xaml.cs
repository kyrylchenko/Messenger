using Messenger.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Messenger.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для AddContactView.xaml
    /// </summary>
    public partial class AddContactView : Window
    {
       
        public AddContactView(MessengerService.MessengerServiceClient client,UserDTO currentUser)
        {
           
            InitializeComponent();
        }

       
    }
}
