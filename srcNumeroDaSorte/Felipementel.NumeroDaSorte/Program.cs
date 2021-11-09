using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felipementel.NumeroDaSorte
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                 .ConfigureFunctionsWorkerDefaults()
                 .Build();

            host.Run();
        }
    }
}