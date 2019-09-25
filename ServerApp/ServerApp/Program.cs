using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            ContextUsers db = new ContextUsers();


            Console.WriteLine("Ожидание клиентов...");

            /*Серверная часть*/
            socket.Bind(new IPEndPoint(IPAddress.Any, 800));
            socket.Listen(1);
            Socket clientSocket = socket.Accept();
            Console.WriteLine("Новое подключение");
            byte[] buffer = new byte[1024];
            clientSocket.Receive(buffer);
            var messageClient = Encoding.ASCII.GetString(buffer);
            var name = "";
            var number = "";
            Console.WriteLine(messageClient);

            var getUser = from user in db.Users
                          where user.PhoneNumber == messageClient
                          select user;
            foreach (var sendUser in getUser)
            {
                name = "FIO: " + sendUser.FIO;
                number = "PhoneNumber: " + sendUser.PhoneNumber;
            }
            byte[] sendMessageNumber = Encoding.ASCII.GetBytes(number);
            byte[] sendMessageFIO = Encoding.ASCII.GetBytes(name);
            clientSocket.Send(sendMessageFIO);
            clientSocket.Send(sendMessageNumber);
            Console.ReadLine();
        }
    }
}
