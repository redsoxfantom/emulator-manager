using EmulatorManager.Utilities;
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
        public String RomPath { get; private set; }

        public String EmulatorToUse { get; private set; }

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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtPathToRomDirectory.Text) || String.IsNullOrEmpty(cbxSelectedEmulator.SelectedText))
            {
                MessageBox.Show(this, "You must define a path to your Roms or define an emulator to use when loading these Roms", "Error");
            }
            else
            {
                RomPath = txtPathToRomDirectory.Text;
                EmulatorToUse = cbxSelectedEmulator.SelectedText;

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
