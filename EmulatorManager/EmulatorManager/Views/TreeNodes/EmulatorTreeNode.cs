using EmulatorManager.Components.ConfigurationManager.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorManager.Views.TreeNodes
{
    public class EmulatorTreeNode : TreeNode
    {
        public Emulator Emulator { get; private set; }

        public EmulatorTreeNode(Emulator emu)
        {
            Text = emu.Name;
            Emulator = emu;
        }
    }
}
