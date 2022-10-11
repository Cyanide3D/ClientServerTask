using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTask
{
    internal class Client
    {

        const String ip = "127.0.0.1";
        const int port = 8080;

        public static void Main(String[] args)
        {
            StartClient();
          
        }

        public static void StartClient()
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);
                    Console.WriteLine("Socket connected to {0}",sender.RemoteEndPoint.ToString());

                
                    int bytesSent = sender.Send(Encoding.ASCII.GetBytes("5"));
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Thread.Sleep(10000);
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
        }
    }
}