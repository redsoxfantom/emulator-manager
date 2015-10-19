﻿using EmulatorManager.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorManager.Views
{
    public partial class ModifyPaths : Form
    {
        public ModifyPaths()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string Path = FileManager.PickFolderToLoad();
            if(Path != null)
            {
                txtPathToRomDirectory.Text = Path;
            }
        }
    }
}
