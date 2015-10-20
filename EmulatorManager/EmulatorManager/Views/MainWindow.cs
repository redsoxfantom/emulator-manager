using EmulatorManager.Events;
using EmulatorManager.Managers;
using EmulatorManager.Managers.ConfigurationManager;
using EmulatorManager.Managers.ExecutionManager;
using EmulatorManager.Managers.ConfigurationManager.DataContracts;
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

        private EmulatorExecutionManager mExecutionManager; 

        private EmulatorManagerConfig mLoadedConfig;

        public MainWindow()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            InitializeComponent();

            mModifyEmulatorsForm = new ModifyEmulators();
            mModifyPathsForm = new ModifyPaths();
            mConfigurationManager = new ConfigManager();
            mLoadedConfig = new EmulatorManagerConfig();
            mExecutionManager = new EmulatorExecutionManager();

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
            if(mLoadedConfig.Emulators.Count == 0)
            {
                String err = "Cannot add a new path as no emulators have been defined in the current configuration! Add a new emulator first.";
                mLogger.Warn(err);
                MessageBox.Show(this, err, "Error");
            }
            else
            {
                mLogger.Info("ModifyPaths clicked, displaying form");

                var loadedEmulators = mLoadedConfig.Emulators.Select(f => f.Name).ToArray();
                mModifyPathsForm.Initialize(loadedEmulators);
                if(mModifyPathsForm.ShowDialog(this) == DialogResult.OK)
                {
                    String path = mModifyPathsForm.RomPath;
                    String associatedEmulator = mModifyPathsForm.EmulatorToUse;
                    mConfigurationManager.AddRomPath(path, associatedEmulator);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String SavePath = FileManager.UseFilePicker(FileManager.FilePickerType.SAVE, extensionFilter: "Emulator Manager Files (*.mgr)|*.mgr");
            if(SavePath != null)
            {
                mConfigurationManager.SaveConfig(SavePath);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String LoadPath = FileManager.UseFilePicker(FileManager.FilePickerType.LOAD, extensionFilter: "Emulator Manager Files (*.mgr)|*.mgr");
            if(LoadPath != null)
            {
                mConfigurationManager.LoadConfig(LoadPath);
            }
        }
    }
}
