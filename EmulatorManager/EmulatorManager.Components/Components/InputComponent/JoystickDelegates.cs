﻿using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.InputComponent
{
    public enum JoystickStatus
    {
        CONNECTED,
        DISCONNECTED
    }

    public delegate void JoystickStatusChanged(JoystickStatus newStatus);

    public delegate void JoystickInput(JoystickUpdate updateEvent);
}
