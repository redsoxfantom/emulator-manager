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
    public partial class AddNewPath : Form
    {
        public String RomPath { get; private set; }

        public String EmulatorToUse { get; private set; }

        private ILog mLogger;

        public AddNewPath()
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
                if(Path.IndexOf(' ') != -1) // Check if path contains a space
                {
                    String warning = String.Format("The selected path '{0}' contains a space. Many emulators do not like this.\nIt is recommended that you enter a path that does not contain a space", Path);
                    mLogger.Warn(warning);
                    MessageBox.Show(this, warning, "Warning");
                }
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            String help = "Filter Roms found in the Path folder based on this extension.\n"+
                          "Ex: If the Extension = \".iso\" and the folder contains the following files:\n"+
                          "     file1.iso\n     file2.bin\n     file3.iso\n"+
                          "than only \"file1\" and \"file3\" will be available to the emulator manager";
            MessageBox.Show(this, help, "Info");
        }
    }
}
