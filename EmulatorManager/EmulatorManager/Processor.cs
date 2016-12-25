using EmulatorManager.Components.ConfigurationManager;
using EmulatorManager.Components.ConfigurationManager.DataContracts;
using EmulatorManager.Components.GameDataComponent;
using EmulatorManager.Utilities;
using EmulatorManager.Views;
using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorManager
{
    public class Processor
    {
        private ILog mLogger;

        private String configPath;

        private String dataUrl;

        public void Init(string[] args)
        {
            ParseArgs(args);
            mLogger = LogManager.GetLogger(GetType().Name);
            mLogger.Info(string.Format("Initializing Emulator Manager processor with args: [{0}]",string.Join(",",args)));

            if (configPath == null)
            {
                configPath = getDefaultFileLocation<EmulatorManagerConfig>("emulators.mgr");
            }
            ConfigComponent.Instance.Initialize(configPath);

            if (dataUrl == null)
            {
                dataUrl = getDefaultFileLocation<Dictionary<string, GameData>>("romdata.json");
            }
            RomDataComponent.Instance.Initialize(dataUrl);

            mLogger.Info("Done Initializing Emulator Manager processor");
        }

        /// <summary>
        /// Gets a default file location. Creates the file (of the specified type T) if it doesn't exist
        /// </summary>
        /// <typeparam name="T">The type of time to create if it doesn't already exist</typeparam>
        /// <param name="fileName">The name of the file to look for</param>
        /// <returns>The path to the file</returns>
        private string getDefaultFileLocation<T>(String fileName) where T: new()
        {
            String configPathRoot = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String fileWithPath = System.IO.Path.Combine(configPathRoot, fileName);
            if (!System.IO.File.Exists(fileWithPath))
            {
                T fileType = new T();
                FileManager.SaveObject(fileType, fileWithPath);
            }

            return fileWithPath;
        }

        public bool Execute()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            using (MainWindow mMainForm = new MainWindow())
            {
                mLogger.Info("Showing main display");
                mMainForm.Initialize();
                Application.Run(mMainForm);
                mLogger.Info("Bye");
            }
            return true;
        }

        private void ParseArgs(string[] args)
        {
            configPath = null;

            for(int i = 0; i < args.Length; i++)
            {
                if(args[i] == "-config")
                {
                    i++;
                    configPath = args[i];
                }
                if(args[i] == "-logLevel")
                {
                    i++;
                    ILoggerRepository logRepo = LogManager.GetRepository();
                    logRepo.Threshold = logRepo.LevelMap[args[i]];
                }
                if(args[i] == "-dataUrl")
                {
                    i++;
                    dataUrl = args[i];
                }
            }
        }
    }
}
