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

        public event JoystickInput OnJoystickInput;

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
                    FireJoystickStatusEvent(JoystickStatus.CONNECTED);

                    pollJoystickLoop(joystick);
                    FireJoystickStatusEvent(JoystickStatus.DISCONNECTED);
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
                        FireJoystickInputEvent(state);
                    }
                }
            }
            catch(SharpDX.SharpDXException)
            {
                mLogger.Info("Gamepad disconnected");
            }
        }
        
        private void FireJoystickStatusEvent(JoystickStatus currentStatus)
        {
            if(OnJoystickStatusChanged != null)
            {
                OnJoystickStatusChanged(currentStatus);
            }
        }

        private void FireJoystickInputEvent(JoystickUpdate updateData)
        {
            if(OnJoystickInput != null)
            {
                OnJoystickInput(updateData);
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
