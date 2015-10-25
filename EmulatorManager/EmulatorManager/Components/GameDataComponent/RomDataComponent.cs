using EmulatorManager.Components.GameDataComponent.RomReaders;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    public class RomDataComponent
    {
        public static RomDataComponent Instance
        {
            get
            {
                if(mInstance == null)
                {
                    mInstance = new RomDataComponent();
                }
                return mInstance;
            }
        }
        private static RomDataComponent mInstance = null;

        private List<IRomReader> mReaders;

        private ILog mLogger;

        private RomDataComponent()
        {
            mReaders = new List<IRomReader>();
            mLogger = LogManager.GetLogger(GetType().Name);
        }

        public void Initialize()
        {
            mLogger.Info("Initializing RomDataComponent");

            // Get list of all types in assembly that implement IRomReader
            Type romReaderType = typeof(IRomReader);
            var implementingTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => romReaderType.IsAssignableFrom(t) && !t.IsInterface);

            foreach(Type t in implementingTypes)
            {
                mLogger.Debug(String.Format("Initializing Rom Reader {0}",t.Name));
                IRomReader reader = (IRomReader)Activator.CreateInstance(t);
                mReaders.Add(reader);
            }

            mLogger.Info("Done Initializing RomDataComponent");
        }
    }
}
