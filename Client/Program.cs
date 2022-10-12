using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Task = Client.Task;

namespace SimpleTask
{
    internal class Client
    {

        public static void Main(String[] args)
        {
            Task task = new Task();
            task.Fifteen();
        }
    }
}