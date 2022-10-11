using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTask.task
{
    internal class Task
    {
        public String Three(String input)
        {
            return Math.Abs(Int16.Parse(input)).ToString();
        }
        public String Six(String input)
        {
            int num = Int16.Parse(input);
            return Math.Log(num + 12 / num).ToString();
        }
        public String Nine(String input)
        {
            StringBuilder builder = new StringBuilder();
            double x, z, Xn = 4.0, Xk = -6.0, dx = 0.91, a = -0.2, b = 0.8;
            for (x = Xn; x >= Xk; x -= dx)
            {
                z = Math.Sin(x) + Math.Cos(x);

                if ((z >= a) && (z <= b))
                {
                    builder.Append(x).Append(":").Append(z).Append(";");
                }
            }

            return builder.ToString();
        }
        public String Twelve(String input)
        {
            int num = 1;
            double y;
            do
            {
                y = Math.Log(9 * num) / (num * num);
                num++;
            } while (y >= 1);

            return y.ToString();
        }
        public String Fifteen(String input)
        {
            int i = Int16.Parse(input);
            return (i * i).ToString();
        }
    }
}
