using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerService.WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IMessengerService" в коде и файле конфигурации.
    [ServiceContract(CallbackContract =typeof(IServiceMessageCallback))]
    public interface IMessengerService
    {
        [OperationContract]
        int Connect(string name);
        [OperationContract]
        void Disconnect(int id);
        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg,int id);


    }
    public interface IServiceMessageCallback
        {
        [OperationContract(IsOneWay =true)]
        void CallBackMsg(string msg);
        }
}
