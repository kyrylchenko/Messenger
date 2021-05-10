using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.DTO
{
    public class UserFriendDTO
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public bool? IsConfirmedFrend { get; set; }

        public bool? IsBlocked { get; set; }

    }
}
