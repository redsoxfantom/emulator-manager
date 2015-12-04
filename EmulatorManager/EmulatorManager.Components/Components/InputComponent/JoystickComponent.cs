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

        private DirectInput directInput;

        private Joystick joystick;

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

            directInput = new DirectInput();
            Task.Factory.StartNew(() => { joystickLoop(); });
        }

        private void joystickLoop()
        {
            while(true)
            {

            }
        }

        private void pollJoystickLoop()
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
                mLogger.Info("Caught SharpDX exception", ex);
            }
        }

        private void joystickConnectionLoop()
        {
            JoystickStatus previousState = JoystickStatus.DISCONNECTED;
            DeviceInstance currentInstance = null;
            
            currentInstance = GetJoystickInstance();

            if (currentInstance != null)
            {
                if (previousState == JoystickStatus.DISCONNECTED)
                {
                    // Only report the gamepad as connected if it was disconnected last time we checked
                    mLogger.InfoFormat("Gamepad Connected. Name: {0}", currentInstance.ProductName);
                    joystick = new Joystick(directInput, currentInstance.InstanceGuid);
                    previousState = JoystickStatus.CONNECTED;
                    FireJoystickStatusEvent(JoystickStatus.DISCONNECTED, JoystickStatus.CONNECTED);
                }
            }
            else
            {
                if (previousState == JoystickStatus.CONNECTED)
                {
                    // Only report the gamepad as disconnected if it was connected last time we checked
                    mLogger.Info("Gamepad disconnected");
                    joystick = null;
                    previousState = JoystickStatus.DISCONNECTED;
                    FireJoystickStatusEvent(JoystickStatus.CONNECTED, JoystickStatus.DISCONNECTED);
                }
            }
        }

        private void FireJoystickStatusEvent(JoystickStatus previousStatus, JoystickStatus currentStatus)
        {
            if(OnJoystickStatusChanged != null)
            {
                OnJoystickStatusChanged(previousStatus, currentStatus);
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
