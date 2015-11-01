using EmulatorManager.Components.GameDataComponent;
using EmulatorManager.Properties;
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
    public partial class UpdateRomDataServerWindow : Form
    {
        private GameData mData;

        private static ILog mLogger;

        public UpdateRomDataServerWindow()
        {
            InitializeComponent();

            mData = new GameData();
             mLogger = LogManager.GetLogger(this.GetType().Name);
        }

        public void Initialize(GameData data)
        {
            mData = data;

            txtGameName.Text = data.GameName;
            txtGamePublisher.Text = data.GamePublisher;
            txtGameSystem.Text = data.GameSystem;
            pnlImage.BackgroundImage = data.GameImage;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gameImage_click(object sender, EventArgs e)
        {
            string imageFile = FileManager.UseFilePicker(FileManager.FilePickerType.LOAD, "Select Game Image", "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG");
            if(!String.IsNullOrEmpty(imageFile))
            {
                try
                {
                    mData.GameImage = Image.FromFile(imageFile);
                    pnlImage.BackgroundImage = mData.GameImage;
                }
                catch(Exception ex)
                {
                    mLogger.Warn("Could not load image", ex);
                    MessageBox.Show(this, String.Format("Could not load image: {0}", ex.Message), "ERROR");
                    mData.GameImage = Resources.No_Image_Found;
                    pnlImage.BackgroundImage = Resources.No_Image_Found;
                }
            }
        }
    }
}
