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

        private static JoystickComponent mInstance;

        public event JoystickStatusChanged OnJoystickStatusChanged;

        public static JoystickComponent Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new JoystickComponent();
                }
                return mInstance;
            }
        }

        private JoystickComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);

            Task.Factory.StartNew(() => { joystickLoop(); });
        }

        private void joystickLoop()
        {
            using (var directInput = new DirectInput())
            {
                while (true)
                {
                    var joystick = connectToJoystick(directInput);
                    FireJoystickStatusEvent(JoystickStatus.DISCONNECTED, JoystickStatus.CONNECTED);

                    pollJoystickLoop(joystick);
                    FireJoystickStatusEvent(JoystickStatus.CONNECTED, JoystickStatus.DISCONNECTED);
                }
            }
        }

        private Joystick connectToJoystick(DirectInput directInput)
        {
            Joystick retVal = null;
            DeviceInstance currentInstance = GetJoystickInstance(directInput);
            while(currentInstance == null)
            {
                currentInstance = GetJoystickInstance(directInput);
            }

            mLogger.InfoFormat("Gamepad Connected. Name: {0}",currentInstance.ProductName);
            retVal = new Joystick(directInput, currentInstance.InstanceGuid);

            return retVal;
        }

        private void pollJoystickLoop(Joystick joystick)
        {
            joystick.Properties.BufferSize = 128;
            joystick.Acquire();

            try
            {
                while (true)
                {
                    joystick.Poll();
                    var data = joystick.GetBufferedData();
                    foreach (var state in data)
                    {

                        mLogger.DebugFormat("{0} state change detected", state);
                    }
                }
            }
            catch(SharpDX.SharpDXException ex)
            {
                mLogger.Info("Gamepad disconnected");
            }
        }
        
        private void FireJoystickStatusEvent(JoystickStatus previousStatus, JoystickStatus currentStatus)
        {
            if(OnJoystickStatusChanged != null)
            {
                OnJoystickStatusChanged(previousStatus, currentStatus);
            }
        }

        private DeviceInstance GetJoystickInstance(DirectInput directInput)
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
