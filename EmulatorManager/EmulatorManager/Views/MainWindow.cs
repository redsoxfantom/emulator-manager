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
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Form displayed when the user selects "Modify Emulators"
        /// </summary>
        private ModifyEmulators mModifyEmulatorsForm;

        /// <summary>
        /// Form displayed when the user selects "Modify Paths"
        /// </summary>
        private ModifyPaths mModifyPathsForm;

        public MainWindow()
        {
            InitializeComponent();

            mModifyEmulatorsForm = new ModifyEmulators();
            mModifyPathsForm = new ModifyPaths();
        }

        private void modfyEmulators_Click(object sender, EventArgs e)
        {
            mModifyEmulatorsForm.ShowDialog(this);
        }

        private void modifyPaths_Click(object sender, EventArgs e)
        {
            mModifyPathsForm.ShowDialog(this);
        }
    }
}
