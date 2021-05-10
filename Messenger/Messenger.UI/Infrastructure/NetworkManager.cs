using Messenger.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.UI.Infrastructure
{
 static   class NetworkManager
    {
        public static MessengerService.MessengerServiceClient Client { get; set; }
        public static UserDTO CurrentUser { set; get; }
    }
}
