using Messenger.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessengerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(MessengerService)))
            {
                host.Open();
                Console.WriteLine("Host Started");
                Console.ForegroundColor = ConsoleColor.Blue;
                //for(int i =0;true;i++)
                //  {
                //      Console.Write("\b\\");
                //      Thread.Sleep(100);
                //      Console.Write("\b|");
                //      Thread.Sleep(100);
                //      Console.Write("\b/");
                //      Thread.Sleep(100);
                //      Console.Write("\b--");
                //      Thread.Sleep(100);               

                //    if(i%10==0)
                //      {
                //          Console.Clear();
                //          Console.WriteLine("Host Started");
                //      }

                //  }
                Console.ReadKey();
            }
        }
    }
}
