using System;
using Ziroh.Misc.Common;
using UserCommon;

namespace ServerApplication
{
    class Service
    {
        public void start(Uri address)
        {
            GenericHttpService<Server, IUserService> service = new GenericHttpService<Server, IUserService>(address.ToString(), false);


            try
            {
                service.StartHost();
                Console.WriteLine("Started");
                Console.ReadKey();

            }

            catch (Exception msg)
            {
                Console.WriteLine(msg);
            }
        }
    }
}