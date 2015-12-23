using EmulatorManager.Utilities;
using log4net;
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
    public partial class EmulatorManagementWindow : Form
    {
        public String EmulatorName { get; private set; }

        public String EmulatorPath { get; private set; }

        public String EmulatorArgs { get; private set; }

        private List<String> mEmulatorNames;

        private ILog mLogger;

        public EmulatorManagementWindow()
        {
            InitializeComponent();

            mLogger = LogManager.GetLogger(GetType().Name);
            mEmulatorNames = new List<string>();
        }

        public void Initialize(List<String> EmulatorNames)
        {
            mEmulatorNames = EmulatorNames;
        }

        public void Initialize(List<String> EmulatorNames, String EmuName, String EmuPath, String EmuArgs)
        {
            mEmulatorNames = EmulatorNames;
            txtEmulatorPath.Text = EmuPath;
            txtEmulatorName.Text = EmuName;
            txtEmulatorArguments.Text = EmuArgs;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the command arguments to the emulator in the same format you would enter them in the command line.\n"+
                            "Enter the following options to determine how the command will be constructed:\n"+
                            "$FULL_PATH: When the manager encounters this, the full path to the selected ROM will be inserted.\n"+
                            "$ROM_PATH: When the manager encounters this, the path to the rom only (without the rom file) will be inserted.\n"+
                            "$ROM_FILE: When the manager encounters this, the rom file only (without the path) will be inserted.","Info");
        }

        private void btnEmulatorBrowse_Click(object sender, EventArgs e)
        {
            string selectedPath = FileManager.UseFilePicker(FileManager.FilePickerType.LOAD, "Select Emulator");
            if(selectedPath != null)
            {
                txtEmulatorPath.Text = selectedPath;
                txtEmulatorName.Text = Path.GetFileNameWithoutExtension(selectedPath);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmulatorPath.Text) || String.IsNullOrEmpty(txtEmulatorName.Text))
            {
                String err = "Emulator Path / Name cannot be empty, please reenter.";
                mLogger.Warn(err);
                MessageBox.Show(this, err, "Error");
            }
            else if(mEmulatorNames.Contains(txtEmulatorName.Text))
            {
                String err = "Emulator Name has already been defined, pick a different one";
                mLogger.Warn(err);
                MessageBox.Show(this, err, "Error");
            }
            else
            {
                EmulatorArgs = txtEmulatorArguments.Text;
                EmulatorName = txtEmulatorName.Text;
                EmulatorPath = txtEmulatorPath.Text;

                // Close the form while returning a successful result
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnEmulatorNameHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter a name for this emulator.\nNote: This name must be unique", "Info");
        }
    }
}
