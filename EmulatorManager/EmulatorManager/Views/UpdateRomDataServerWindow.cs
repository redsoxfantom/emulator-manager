﻿using EmulatorManager.Components.GameDataComponent;
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

        public UpdateRomDataServerWindow()
        {
            InitializeComponent();

            mData = new GameData();
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

        }

        private void gameImage_click(object sender, EventArgs e)
        {

        }
    }
}
