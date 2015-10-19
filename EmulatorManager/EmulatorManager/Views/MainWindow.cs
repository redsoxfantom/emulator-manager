﻿using EmulatorManager.Events;
using EmulatorManager.GlobalManager;
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

        private ILog mLogger;

        private Manager mEmulatorManager;

        public MainWindow()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            InitializeComponent();

            mModifyEmulatorsForm = new ModifyEmulators();
            mModifyPathsForm = new ModifyPaths();
            mEmulatorManager = new Manager();

            mEmulatorManager.ConfigutationChanged += MEmulatorManager_ConfigutationChanged;
            mEmulatorManager.Initialize();
        }

        private void MEmulatorManager_ConfigutationChanged(LoadedConfigChangedArgs args)
        {
            managerConfigToolStripMenuItem.Text = args.ConfigFileName;
        }

        private void modfyEmulators_Click(object sender, EventArgs e)
        {
            mLogger.Info("ModifyEmulators clicked, displaying form");
            mModifyEmulatorsForm.ShowDialog(this);
        }

        private void modifyPaths_Click(object sender, EventArgs e)
        {
            mLogger.Info("ModifyPaths clicked, displaying form");
            mModifyPathsForm.ShowDialog(this);
        }
    }
}
