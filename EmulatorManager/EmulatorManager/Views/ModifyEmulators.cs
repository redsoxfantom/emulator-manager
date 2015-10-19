using EmulatorManager.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorManager.Views
{
    public partial class ModifyEmulators : Form
    {
        public String EmulatorName { get; private set; }

        public String EmulatorPath { get; private set; }

        public String EmulatorArgs { get; private set; }

        public ModifyEmulators()
        {
            InitializeComponent();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the command arguments to the emulator in the same format you would enter them in the command line.\n"+
                            "Where you would put a rom, instead put a {0}.\n"+
                            "For example:\n"+
                            "If the old arguments to an emulator were\n"+"-exec \"path/to/rom.bin\"\n"+"You would instead put\n"+"-exec \"{0}\"");
        }

        private void btnEmulatorBrowse_Click(object sender, EventArgs e)
        {
            string selectedPath = FileManager.PickFileToLoad("Select Emulator");
            if(selectedPath != null)
            {
                txtEmulatorPath.Text = selectedPath;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmulatorPath.Text))
            {
                MessageBox.Show(this, "Emulator Path cannot be empty, please reenter.", "Error");
            }
            else
            {
                EmulatorArgs = txtEmulatorArguments.Text;
                EmulatorName = Path.GetFileNameWithoutExtension(txtEmulatorPath.Text);
                EmulatorPath = txtEmulatorPath.Text;
            }
        }
    }
}
