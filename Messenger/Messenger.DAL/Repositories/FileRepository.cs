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
    
    public class FileRepository : GenericRepository<File>
    {
        public FileRepository(DbContext context) : base(context)
        {
        }
    }
}
