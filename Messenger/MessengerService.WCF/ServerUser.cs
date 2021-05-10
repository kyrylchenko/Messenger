using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessengerService.WCF
{
    class ServerUser
    {
        public int Id { set; get;}
        public string Name { set; get; }
      public  OperationContext OperationContext { set; get; }

    }
}
