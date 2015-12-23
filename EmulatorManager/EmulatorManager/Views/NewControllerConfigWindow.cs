using EmulatorManager.Components.InputComponent;
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
    public partial class NewControllerConfigWindow : Form
    {
        private JoystickComponent mJoystickComponent;

        public NewControllerConfigWindow()
        {
            InitializeComponent();

            mJoystickComponent = JoystickComponent.Instance;
            mJoystickComponent.OnJoystickInput += OnJoystickInput;
        }

        private void OnJoystickInput(SharpDX.DirectInput.JoystickUpdate updateEvent)
        {
            throw new NotImplementedException();
        }
    }
}
