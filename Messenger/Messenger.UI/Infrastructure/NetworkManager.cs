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

        private static readonly object lockObj = new object ();
        private static MessengerService.MessengerServiceClient client;
        public static MessengerService.MessengerServiceClient Client
        {
            get
            {
                lock(lockObj)
                    return client;
            }
            set
            {
                lock(lockObj)
                    client = value;
            }
        }
        public static UserDTO CurrentUser { set; get; }
    }
}
