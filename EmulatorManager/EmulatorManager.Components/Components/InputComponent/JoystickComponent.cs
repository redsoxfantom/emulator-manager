using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.InputComponent
{
    public class JoystickComponent
    {
        private ILog mLogger;

        private JoystickComponent mInstance;

        private JoystickComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
        }

        public JoystickComponent Instance
        {
            get
            {
                if(mInstance == null)
                {
                    mInstance = new JoystickComponent();
                }
                return mInstance;
            }
        }
    }
}
