﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.GlobalManager.DataContracts
{
    public class Emulator
    {
        public string Path;
        
        public string Executable;
        
        public string Arguments;
    }
}