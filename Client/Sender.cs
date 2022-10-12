using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Sender
    {
        public String Send(String input)
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost"); //Берем локальный IP адрес
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000); //Создаём эндпоинт с IP и портом сервера, берём локалхост так как сервер на нём висит

                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp); //Создаём сокет

                try
                {
                    sender.Connect(remoteEP); //Конектимся к серверу
                    int bytesSent = sender.Send(Encoding.ASCII.GetBytes(input)); //Получаем байты из строки и отправляем на сервер
                    int bytesRec = sender.Receive(bytes); //Получаем ответ
                    String result = Encoding.ASCII.GetString(bytes, 0, bytesRec); //Трансформируем байты в строку
                    sender.Shutdown(SocketShutdown.Both); //Бахаем соединение
                    sender.Close();
                    return result;
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return "";
        }
    }
}
