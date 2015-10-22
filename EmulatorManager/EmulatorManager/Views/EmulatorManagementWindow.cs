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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the command arguments to the emulator in the same format you would enter them in the command line.\n"+
                            "Where you would put a rom, instead put a {0}.\n"+
                            "For example:\n"+
                            "If the old arguments to an emulator were\n"+"-exec \"path/to/rom.bin\"\n"+"You would instead put\n"+"-exec \"{0}\"","Info");
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
