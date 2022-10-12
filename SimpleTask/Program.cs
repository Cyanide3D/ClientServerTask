using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Task = Server.Task;

namespace SimpleTask
{
    internal class Server
    {

        public static int Main(String[] args)
        {
            StartServer();
            return 0;
        }

        public static void StartServer()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            try
            {
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint); //До этого момента всё так же как и в Sender. Тут же мы присваеваем сокету созданный эндпоинт.
                listener.Listen(10); //Вешаем сокет на прослушиввание входящих соединений, в скобках указываем сколько клиентом могут одновременно обслуживаться

                Console.WriteLine("Waiting for a connection...");
                while (true) //Вечно будем принимать запросы
                {
                    Socket handler = listener.Accept(); //Метод Accept блочит поток и ждёт нового подключения, после чего будет выполняться код дальше
                    string data = null;
                    byte[] bytes = null;

                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec); //Получаем байты и пихаем их в строчку
                        if (handler.Available <= 0) //Если во входном потоке не осталось байтов то прекращаем считывать
                        {
                            break;
                        }
                    }

                    var task = new Task();
                    byte[] msg = Encoding.ASCII.GetBytes(task.Fifteen(data)); //Тут меняем метод, когда нужно сменить задачу
                    handler.Send(msg); //Отправляем ответ клиенту
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }

    }
}
