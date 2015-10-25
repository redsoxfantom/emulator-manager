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
    }
}
