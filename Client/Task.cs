using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Task
    {

        private Sender sender = new Sender();

        public void Three()
        {
            int i = 0;

            Console.WriteLine("Enter number");
            while ((i = Int16.Parse(Console.ReadLine())) >= 0)
            {
                Console.WriteLine("Result: " + sender.Send(i.ToString()));
            }
        }
        public void Six()
        {
            while (true)
            {
                Console.WriteLine("Enter number");
                int num = Int16.Parse(Console.ReadLine());
                if (num < 1) break;
                Console.WriteLine("Result: " + sender.Send(num.ToString()));
            }
        }
        public void Nine()
        {
            foreach (String line in sender.Send("123").Split(";"))
            {
                String[] p = line.Split(":");
                if (p.Length == 2)
                {
                    Console.WriteLine("x = " + p[0] + " z = " + p[1]);
                }
            }

            Thread.Sleep(5000);
        }
        public void Twelve()
        {
            Console.WriteLine("Result: " + sender.Send("123"));
            Thread.Sleep(5000);
        }
        public void Fifteen()
        {
            while (true)
            {
                Console.WriteLine("Enter number");
                int num = Int16.Parse(Console.ReadLine());
                if (num > 0 && num % 3 == 0) break;
                Console.WriteLine("Result: " + sender.Send(num.ToString()));
            }
        }
    }
}
