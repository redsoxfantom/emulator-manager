using EmulatorManager.Events;
using EmulatorManager.Components;
using EmulatorManager.Components.ConfigurationManager;
using EmulatorManager.Components.ExecutionComponent;
using EmulatorManager.Components.ConfigurationManager.DataContracts;
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
using EmulatorManager.Components.PathComponent;

namespace EmulatorManager.Views
{
    public partial class MainWindow : Form
    {
        private ILog mLogger;

        private ConfigComponent mConfigurationComponent;

        private EmulatorExecutionComponent mExecutionComponent;

        private PathResolverComponent mPathResolver;

        private EmulatorManagerConfig mLoadedConfig;

        public MainWindow()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            InitializeComponent();
            
            mConfigurationComponent = new ConfigComponent();
            mLoadedConfig = new EmulatorManagerConfig();
            mExecutionComponent = new EmulatorExecutionComponent();
            mPathResolver = new PathResolverComponent();

            mConfigurationComponent.ConfigutationChanged += MEmulatorManager_ConfigutationChanged;
            mConfigurationComponent.Initialize();
        }

        private void MEmulatorManager_ConfigutationChanged(LoadedConfigChangedArgs args)
        {
            mLoadedConfig = args.NewConfig;
            managerConfigToolStripMenuItem.Text = mLoadedConfig.GetFileName();

            redrawTreeView();
        }

        private void redrawTreeView()
        {
            treeEmulatorView.Nodes.Clear();

            treeEmulatorView.Nodes.Add(mLoadedConfig.GetFileName());
        }

        private void modifyEmulators_Click(object sender, EventArgs e)
        {
            using (ModifyEmulators mModifyEmulatorsForm = new ModifyEmulators())
            {
                mLogger.Info("ModifyEmulators clicked, displaying form");
                if (mModifyEmulatorsForm.ShowDialog(this) == DialogResult.OK)
                {
                    String name = mModifyEmulatorsForm.EmulatorName;
                    String path = mModifyEmulatorsForm.EmulatorPath;
                    String args = mModifyEmulatorsForm.EmulatorArgs;
                    mConfigurationComponent.AddEmulator(name, path, args);
                }
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
                using (ModifyPaths mModifyPathsForm = new ModifyPaths())
                {
                    mLogger.Info("ModifyPaths clicked, displaying form");

                    var loadedEmulators = mLoadedConfig.Emulators.Select(f => f.Name).ToArray();
                    mModifyPathsForm.Initialize(loadedEmulators);
                    if (mModifyPathsForm.ShowDialog(this) == DialogResult.OK)
                    {
                        String path = mModifyPathsForm.RomPath;
                        String associatedEmulator = mModifyPathsForm.EmulatorToUse;
                        mConfigurationComponent.AddRomPath(path, associatedEmulator);
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String SavePath = FileManager.UseFilePicker(FileManager.FilePickerType.SAVE, extensionFilter: "Emulator Manager Files (*.mgr)|*.mgr");
            if(SavePath != null)
            {
                mConfigurationComponent.SaveConfig(SavePath);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String LoadPath = FileManager.UseFilePicker(FileManager.FilePickerType.LOAD, extensionFilter: "Emulator Manager Files (*.mgr)|*.mgr");
            if(LoadPath != null)
            {
                mConfigurationComponent.LoadConfig(LoadPath);
            }
        }

        private void btnExecuteEmulator_Click(object sender, EventArgs e)
        {

        }
    }
}
