using log4net;
using SharpDX.DirectInput;
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

        private Joystick joystickInstance;

        private DirectInput directInput;

        private JoystickComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);

            directInput = new DirectInput();

            var joystickInstance = GetJoystickInstance();
            if(joystickInstance == null)
            {
                mLogger.WarnFormat("No gamepad connected");
            }
            else
            {
                mLogger.InfoFormat("Gamepad detected. Name: {0}",joystickInstance.ProductName);
            }
        }

        public static JoystickComponent Instance
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

        private DeviceInstance GetJoystickInstance()
        {
            var devices = directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
            if(devices.Count > 0)
            {
                return devices[0];
            }
            return null;
        }
    }
}
