using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new HttpProxy();
            proxy.Start(8000);
            Console.Read();
        }
    }
}
