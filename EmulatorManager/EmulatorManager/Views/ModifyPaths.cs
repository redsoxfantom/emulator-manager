using EmulatorManager.Utilities;
using log4net;
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

        private ILog mLogger;

        public ModifyPaths()
        {
            InitializeComponent();

            mLogger = LogManager.GetLogger(GetType().Name);
        }

        public void Initialize(string[] LoadedEmulators)
        {
            cbxSelectedEmulator.Items.AddRange(LoadedEmulators);
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
            if(String.IsNullOrEmpty(txtPathToRomDirectory.Text) || String.IsNullOrEmpty((string)cbxSelectedEmulator.SelectedItem))
            {
                String err = "You must define a path to your Roms or define an emulator to use when loading these Roms";
                mLogger.Warn(err);
                MessageBox.Show(this, err, "Error");
            }
            else
            {
                RomPath = txtPathToRomDirectory.Text;
                EmulatorToUse = (string)cbxSelectedEmulator.SelectedItem;

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
