﻿using EmulatorManager.Events;
using EmulatorManager.Managers;
using EmulatorManager.Managers.ConfigurationManager;
using EmulatorManager.Managers.ConfigurationManager.DataContracts;
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

        private ConfigManager mConfigurationManager;

        private EmulatorManagerConfig mLoadedConfig;

        public MainWindow()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            InitializeComponent();

            mModifyEmulatorsForm = new ModifyEmulators();
            mModifyPathsForm = new ModifyPaths();
            mConfigurationManager = new ConfigManager();
            mLoadedConfig = new EmulatorManagerConfig();

            mConfigurationManager.ConfigutationChanged += MEmulatorManager_ConfigutationChanged;
            mConfigurationManager.Initialize();
        }

        private void MEmulatorManager_ConfigutationChanged(LoadedConfigChangedArgs args)
        {
            mLoadedConfig = args.NewConfig;
            managerConfigToolStripMenuItem.Text = mLoadedConfig.GetFileName();
        }

        private void modfyEmulators_Click(object sender, EventArgs e)
        {
            mLogger.Info("ModifyEmulators clicked, displaying form");
            if(mModifyEmulatorsForm.ShowDialog(this) == DialogResult.OK)
            {
                String name = mModifyEmulatorsForm.EmulatorName;
                String path = mModifyEmulatorsForm.EmulatorPath;
                String args = mModifyEmulatorsForm.EmulatorArgs;
                mConfigurationManager.AddEmulator(name, path, args);
            }
        }

        private void modifyPaths_Click(object sender, EventArgs e)
        {
            mLogger.Info("ModifyPaths clicked, displaying form");
            mModifyPathsForm.ShowDialog(this);
        }
    }
}
