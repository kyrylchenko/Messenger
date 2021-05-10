using Messenger.DAL.EFContext;
using Messenger.DAL.Infrastucture;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DbContext userContext) : base(userContext)
        {
        }
    }
}
