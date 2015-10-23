using EmulatorManager.Components.ConfigurationManager.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorManager.Views.TreeNodes
{
    public class PathTreeNode : TreeNode
    {
        public RomPath RomPath { get; private set; }

        public PathTreeNode(string text, RomPath path)
        {
            Text = text;
            RomPath = path;
        }
    }
}
