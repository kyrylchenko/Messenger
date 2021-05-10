using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Photo { get; set; }//file id
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? IsOnline { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsConfirmed { get; set; }

  
    }

}
