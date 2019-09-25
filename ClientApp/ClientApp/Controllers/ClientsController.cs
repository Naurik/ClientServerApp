using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClientApp.Controllers
{
    public class ClientsController : Controller
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        // GET: Clients/Create
        public ActionResult Index()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            /*Отправка сообщения, для проверки его наличии в бд*/
            socket.Connect("127.0.0.1", 800);
            byte[] buffer = Encoding.ASCII.GetBytes(client.PhoneNumber);
            socket.Send(buffer);

            /*Получение ФИО человека*/
            byte[] answerServerFIO = new byte[1024];
            socket.Receive(answerServerFIO);
            var messageServerName = Encoding.ASCII.GetString(answerServerFIO);
            ViewBag.MessageName = messageServerName;

            /*Получение номера*/
            byte[] answerServerNumber = new byte[1024];
            socket.Receive(answerServerNumber);
            var messageServerNumber = Encoding.ASCII.GetString(answerServerNumber);
            ViewBag.MessageNumber = messageServerNumber;
            return View(nameof(ShowClient));
        }

        public ActionResult ShowClient()
        {
            return View();
        }
    }
}
