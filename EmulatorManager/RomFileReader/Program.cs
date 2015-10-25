using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor proc = new Processor();

            if (proc.Initialize(args))
            {
                proc.Run();
            }
            else
            {
                Console.WriteLine("Failed to initialize processor");
            }

            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
    }
}
