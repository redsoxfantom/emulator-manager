using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace EmulatorManager
{
    class MainExecutable
    {
        [STAThread]
        static void Main(string[] args)
        {
            Processor proc = new Processor();

            proc.Init(args);

            // Execute and check the return code
            if(proc.Execute())
            {
                Environment.Exit(0); // Success
            }
            else
            {
                Environment.Exit(1); // Failed
            }
        }
    }
}
