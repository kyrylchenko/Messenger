using Messenger.BLL.DTO;
using Messenger.BLL.Services;
using MessengerExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "MessengerService" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class MessengerService : IMessengerService
    {

        public UserService userService = new UserService();
        public MessageService messageService = new MessageService();
        public ChatService chatService = new ChatService();
        public ChatUserService chatUserService = new ChatUserService();
        public FileService fileService = new FileService();


        private Dictionary<UserDTO, OperationContext> OnlineUsers { set; get; } = new Dictionary<UserDTO, OperationContext>();



        public UserDTO Connect(string email, string password)
        {
            Directory.CreateDirectory("files");
            UserDTO connectingUser = userService.GetAll().FirstOrDefault((dto) => dto.Email == email);
            if (connectingUser == null)
                throw new FaultException("Inccorect login");
            if (connectingUser.Password == password)
            {
                if (OnlineUsers.Keys.FirstOrDefault((user) => user.UserId == connectingUser.UserId) != null)
                    OnlineUsers.Remove(OnlineUsers.Keys.FirstOrDefault((user) => user.UserId == connectingUser.UserId));
                OnlineUsers.Add(connectingUser, OperationContext.Current);
                return connectingUser;
            }
            throw new FaultException("Inccorect password");
        }
        public bool? Registration(UserDTO user)
        {
            if (userService.GetAll().FirstOrDefault((u) => u.Email == user.Email) != null)
                throw new FaultException("This email alredy registered");
            userService.UpdeteOrCreate(user);
            userService.SaveChanges();
            return true;

        }
     

        public void Disconnect(UserDTO user)
        {
            OnlineUsers.Remove(OnlineUsers.Keys.FirstOrDefault((u) => u.UserId == user.UserId));
        }

        public IEnumerable<ChatDTO> GetChats(UserDTO user)
        {

            return chatService.GetAll().Where((chat) => chatUserService.GetAll()
                                                           .Where((chatUser) => chatUser.UserId == user.UserId)
                                                                      .Select((chatUser) => chatUser.ChatId).FirstOrDefault((id) => id == chat.ChatId) != 0);
        }

        public IEnumerable<ChatUserDTO> GetChatUsers(ChatDTO chat)
        {
            return chatUserService.GetAll().Where((chatUser) => chatUser.ChatId == chat.ChatId);
        }

        public IEnumerable<MessageDTO> GetMessages(ChatDTO chat)
        {
            return messageService.GetAll().Where((msg) => msg.ChatId == chat.ChatId);
        }




        public void SendMessage(MessageDTO message)
        {
            Task.Run(() =>
            {
                UserDTO foundUser;

                foreach (var user in chatUserService.GetAll()
                                                        .Where((chatUser) => chatUser.ChatId == message.ChatId && chatUser.UserId != message.SenderId)
                                                                      .Select((chatUser) => chatUser.UserId))
                    if ((foundUser = OnlineUsers.Keys.FirstOrDefault((u) => u.UserId == user)) != null)
                    {
                        message.IsSent = true;
                        OnlineUsers[foundUser].GetCallbackChannel<IServiceMessangerCallback>().CallBackMsg(message);

                    }


                messageService.UpdeteOrCreate(message);
                messageService.SaveChanges();
            });
        }

        public void UpdateMessage(MessageDTO msg)
        {

        }
        public UserDTO GetUser(int userID)
        {
            Console.WriteLine($"server get user id {userID}");
            return userService.Get(userID);
        }
        public ChatDTO CreateChat(ChatDTO chat, List<ChatUserDTO> chatUsers)
        {


            int temporaryId = new Random().Next(1, 100000);
            chatService.UpdeteOrCreate(new ChatDTO() { Name = $"{temporaryId}" });
            chatService.SaveChanges();
            chat.ChatId = chatService.GetAll().FirstOrDefault((c) => c.Name == $"{temporaryId}").ChatId;
            chatService.UpdeteOrCreate(chat);
            chatService.SaveChanges();
            foreach (var u in chatUsers)
            {
                u.ChatId = chat.ChatId;
                chatUserService.UpdeteOrCreate(u);
                
            }
                chatUserService.SaveChanges();
            foreach (var u in chatUsers)
                NotifyUserAboutCreatedChat(u.UserId, chat);
            return chat;
        }


    
    public UserDTO AddContact(string contactEmail, UserDTO user)
    {
        UserDTO addingContact;
        if ((addingContact = userService.GetAll().FirstOrDefault((u) => u.Email == contactEmail)) == null)
            throw new FaultException("Inccorect email");
        int temporaryId = new Random().Next(1, 100000);
        chatService.UpdeteOrCreate(new ChatDTO() { IsPrivateChat = true, Name = $"{temporaryId}" });
        chatService.SaveChanges();
        ChatDTO createdChat = chatService.GetAll().FirstOrDefault((c) => c.Name == $"{temporaryId}");
            createdChat.Name = "Private chat";                
        chatService.UpdeteOrCreate(createdChat);            chatService.SaveChanges();
        chatUserService.UpdeteOrCreate(new ChatUserDTO() { IsCreator = true, IsAdmin = true, UserId = addingContact.UserId, ChatId = createdChat.ChatId });
        chatUserService.UpdeteOrCreate(new ChatUserDTO() { IsCreator = true, IsAdmin = true, UserId = user.UserId, ChatId = createdChat.ChatId });
        chatUserService.SaveChanges();
        NotifyUserAboutCreatedChat(addingContact.UserId, createdChat);
        NotifyUserAboutCreatedChat(user.UserId, createdChat);
        return addingContact;

    }

    private void NotifyUserAboutCreatedChat(int userId, ChatDTO chat)
    {
        UserDTO findindUser;
        if ((findindUser = OnlineUsers.Keys.FirstOrDefault((u) => u.UserId == userId)) != null)
        {
                Task.Run(() =>
                {
                    OnlineUsers[findindUser].GetCallbackChannel<IServiceMessangerCallback>().CallBackChatAdded(chat);
                });

        }
    }


    public UploadFileInfo UploadFile(UploadFileRequest info)
    {
        FileDTO file = new FileDTO() { FilePath = info.filePath };
        fileService.UpdeteOrCreate(file);
        fileService.SaveChanges();
        file = fileService.GetAll().FirstOrDefault((f) => f.FilePath == info.filePath);
        file.FilePath = $"files\\{file.FileId}.{file.FilePath}";
        fileService.UpdeteOrCreate(file);
        fileService.SaveChanges();
        using (var fileStream = File.Create(file.FilePath))
        {
            info.FileByteStream.Seek(0, SeekOrigin.Begin);
            info.FileByteStream.CopyTo(fileStream);
        }
        return new UploadFileInfo() { file = file };
    }

    public DownloadFileInfo DownloadFile(DownloadFileRequest request)
    {
            
        FileDTO file = fileService.GetAll().FirstOrDefault((f) => f.FileId == request.fileId);
        DownloadFileInfo downloadFileInfo = new DownloadFileInfo();
        downloadFileInfo.fileName = Path.GetFileName(file.FilePath);
            downloadFileInfo.FileByteStream = new MemoryStream();
        using (var fileStream = File.OpenRead(file.FilePath))
        {
            fileStream.Seek(0, SeekOrigin.Begin);
            fileStream.CopyTo(downloadFileInfo.FileByteStream);
        }
        return downloadFileInfo;
    }
}
    }

