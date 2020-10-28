using System;

namespace ServerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();

            Uri baseAddress = new Uri("http://127.0.0.1:8080");

            service.start(baseAddress);

            Console.ReadKey();
        }
    }
}
