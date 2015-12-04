using EmulatorManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace EmulatorManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Processor proc = new Processor();
            proc.Init(args);
            proc.Execute();
        }
    }
}
