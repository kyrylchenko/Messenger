using Messenger.BLL.DTO;
using Messenger.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TestMessengerClient.ServiceReference;

namespace TestMessengerClient
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Test test = new Test();
            test.Work();
        }
        

    }
    class Test: ServiceReference.IMessengerServiceCallback
    { 
        public Test ()
        {

        }

      

        public void CallBackMsg(MessageDTO msg)
        {
            Console.WriteLine($"------- {msg.Text}");
        }

        public void Work()
        {
        //    MessageDTO msg = new MessageDTO() { Text = "test", SenderId = 1, ChatId = 3, SendTime = DateTime.Now ,MessageType = MessageType.Text};
        //    MessageService ms = new MessageService();
        //    ms.UpdeteOrCreate(msg);
        //    ms.SaveChanges();

            UserService service = new UserService();
            foreach (var dto in service.GetAll())
                Console.WriteLine($"id {dto.UserId}  email  {dto.Email} pw {dto.Password}   name  {dto.Name}");
            ServiceReference.MessengerServiceClient client = new ServiceReference.MessengerServiceClient(new InstanceContext(this));
            Console.Write("Enter email_");
            string email = Console.ReadLine();
            Console.Write("Enter PW_");
            string password = Console.ReadLine();
            UserDTO user = client.Connect(email, password);
            Console.Write("Confirmed!");

            while (true)
            {
                Console.WriteLine("Enter msg:");
                string txt = Console.ReadLine();
                if (txt == "break")
                    client.Disconnect(user);
                MessageDTO msg = new MessageDTO() { Text = txt, SenderId = user.UserId, ChatId = 3, SendTime = DateTime.Now };
                client.SendMessage(msg);
            }

        }
    }

}
