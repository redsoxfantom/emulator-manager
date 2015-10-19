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
        private ModifyEmulators mModifyEmulatorsForm;

        public MainWindow()
        {
            InitializeComponent();

            mModifyEmulatorsForm = new ModifyEmulators();
        }

        private void modfyEmulators_Click(object sender, EventArgs e)
        {
            mModifyEmulatorsForm.ShowDialog(this);
        }

        private void modifyPaths_Click(object sender, EventArgs e)
        {

        }
    }
}
