using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerService.WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "MessengerService" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MessengerService : IMessengerService
    {
        List<ServerUser> users = new List<ServerUser>();
        int startId = 1;
        public int Connect(string name)
        {
         ServerUser user = new ServerUser() { Id = startId++, Name = name ,OperationContext = OperationContext.Current};
            SendMsg(user.Name + " connected",user.Id);
            users.Add(user);
            return user.Id;
         
        }

        public void Disconnect(int id)
        {
            ServerUser user = users.FirstOrDefault((u) => u.Id == id);
            if(user!= null)
            {
                SendMsg($"{user.Name } Disconnected",0);
                users.Remove(user);
            }
            

        }

        public void SendMsg(string msg,int id)
        {
            Console.WriteLine("where?");
           foreach(var user in users)
            {
                string message="";
                var userWhoSended = users.FirstOrDefault((u) => u.Id == id);
                if (userWhoSended != null)
                {
                    message = $"{DateTime.Now.ToShortTimeString()} {userWhoSended.Name} : ";
                    message += msg;
                    user.OperationContext.GetCallbackChannel<IServiceMessageCallback>().CallBackMsg(message);
                }
            }
        }
    }
}
