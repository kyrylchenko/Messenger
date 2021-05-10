using Messenger.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestHost
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IMessengerService" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServiceMessangerCallback))]
    public interface IMessengerService
    {
        [OperationContract]
        UserDTO Connect(string email, string password);
        [OperationContract(IsOneWay = true)]
        void SendMessage(MessageDTO message);
        [OperationContract]
        UploadFileInfo UploadFile(UploadFileRequest info);
        [OperationContract]
        DownloadFileInfo DownloadFile(DownloadFileRequest info);
        [OperationContract]
        void Disconnect(UserDTO user);
        [OperationContract]
        IEnumerable<ChatDTO> GetChats(UserDTO user);
        [OperationContract]
        IEnumerable<MessageDTO> GetMessages(ChatDTO chat);
        [OperationContract]
        IEnumerable<ChatUserDTO> GetChatUsers(ChatDTO chat);
        [OperationContract]
        void UpdateMessage(MessageDTO msg);
        [OperationContract]
        UserDTO GetUser(int userId);
        [OperationContract]
        bool? Registration(UserDTO user);
        [OperationContract]
        UserDTO AddContact(string contactEmail, UserDTO user);
        [OperationContract]
        ChatDTO CreateChat(ChatDTO chat, List<ChatUserDTO> chatUsers);
    }
    public interface IServiceMessangerCallback
    {
        [OperationContract(IsOneWay = true)]
        void CallBackMsg(MessageDTO msg);
        [OperationContract(IsOneWay = true)]
        void CallBackChatAdded(ChatDTO chat);
    }


    [MessageContract]
    public class UploadFileInfo
    {
        [MessageBodyMember]
        public FileDTO file;
    }
    [MessageContract]
    public class DownloadFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public int fileId;
        [MessageHeader(MustUnderstand = true)]
        public string fileName;
        [MessageBodyMember]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
    [MessageContract]
    public class DownloadFileRequest
    {
        [MessageBodyMember]
        public int fileId;

    }
    [MessageContract]
    public class UploadFileRequest : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string filePath;
        [MessageBodyMember]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
