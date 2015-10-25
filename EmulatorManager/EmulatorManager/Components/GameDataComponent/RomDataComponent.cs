using EmulatorManager.Components.GameDataComponent.RomReaders;
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

        private RomDataComponent()
        {
            mReaders = new List<IRomReader>();
        }

        public void Initialize()
        {
            // Get list of all types in assembly that implement IRomReader
            Type romReaderType = typeof(IRomReader);
            var implementingTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => romReaderType.IsAssignableFrom(t));

            foreach(Type t in implementingTypes)
            {
                IRomReader reader = (IRomReader)Activator.CreateInstance(t);
                mReaders.Add(reader);
            }
        }
    }
}
