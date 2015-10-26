using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    public class RomDataAccessor
    {
        string mUrl;

        public RomDataAccessor(string dataUrl)
        {
            mUrl = dataUrl;
        }
    }
}
