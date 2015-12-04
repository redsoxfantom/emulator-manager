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

        private bool joystickConnected;

        private JoystickComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            joystickConnected = false;

            directInput = new DirectInput();

            Task.Factory.StartNew(() => { joystickConnectionLoop(); });

            var joystickInstance = GetJoystickInstance();
            if(joystickInstance == null)
            {
                mLogger.WarnFormat("No gamepad connected");
            }
            else
            {
                mLogger.InfoFormat("Gamepad detected. Name: {0}",joystickInstance.ProductName);
                joystick = new Joystick(directInput, joystickInstance.InstanceGuid);
                Task.Factory.StartNew(() => { pollJoystickLoop(); });
            }
        }

        private void pollJoystickLoop()
        {
            joystick.Properties.BufferSize = 128;
            joystick.Acquire();

            while (true)
            {
                joystick.Poll();
                var data = joystick.GetBufferedData();
                foreach(var state in data)
                {
                    
                    mLogger.DebugFormat("{0} state change detected",state);
                }
            }
        }

        private void joystickConnectionLoop()
        {
            DeviceInstance previousInstance = null;
            DeviceInstance currentInstance = null;

            while(true)
            {                
                currentInstance = GetJoystickInstance();

                if (currentInstance != null)
                {
                    if (previousInstance == null)
                    {
                        // Only report the gamepad as connected if it was disconnected last time we checked
                        previousInstance = currentInstance;
                        mLogger.InfoFormat("Gamepad Connected. Name: {0}", currentInstance.ProductName);
                        joystickConnected = true;
                    }
                }
                else
                {
                    if (previousInstance != null)
                    {
                        // Only report the gamepad as disconnected if it was connected last time we checked
                        mLogger.Info("Gamepad disconnected");
                        joystickConnected = false;
                    }
                    else
                    {
                        previousInstance = null;
                    }
                }
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
