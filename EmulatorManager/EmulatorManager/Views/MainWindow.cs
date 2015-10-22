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
using System.Collections.Concurrent;

namespace EmulatorManager.Views
{
    public partial class MainWindow : Form
    {
        private ILog mLogger;

        private ConfigComponent mConfigurationComponent;

        private EmulatorExecutionComponent mExecutionComponent;

        private PathResolverComponent mPathResolver;

        private String mConfigFileName;

        private IReadOnlyList<Emulator> mLoadedEmulators;

        private IReadOnlyList<RomPath> mLoadedPaths;

        private Command CurrentCommand
        {
            get
            {
                return mCurrentCommand;
            }
            set
            {
                mCurrentCommand = value;
                txtCommandLine.Text = mCurrentCommand.ToString();
            }
        }
        private Command mCurrentCommand;

        public MainWindow()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            InitializeComponent();

            mConfigurationComponent = ConfigComponent.Instance;
            mConfigurationComponent.GetCurrentConfig(out mConfigFileName, out mLoadedEmulators, out mLoadedPaths);
            mExecutionComponent = new EmulatorExecutionComponent();
            mPathResolver = new PathResolverComponent();
            CurrentCommand = new Command();

        }

        public void Initialize()
        {
            mConfigurationComponent.ConfigutationChanged += MEmulatorManager_ConfigutationChanged;
            processConfig();
        }

        private void processConfig()
        {
            managerConfigToolStripMenuItem.Text = mConfigFileName;

            redrawTreeView();
        }

        private void MEmulatorManager_ConfigutationChanged(LoadedConfigChangedArgs args)
        {
            mConfigFileName = args.FileName;
            mLoadedEmulators = args.LoadedEmulators;
            mLoadedPaths = args.LoadedPaths;

            processConfig();
        }

        private void redrawTreeView()
        {
            treeEmulatorView.Nodes.Clear();
            treeEmulatorView.Nodes.Add(mConfigFileName);
            TreeNode rootNode = treeEmulatorView.Nodes[0];
            
            foreach(Emulator emu in mLoadedEmulators)
            {
                TreeNode emulatorNode = new TreeNode(emu.Name);

                var associatedPaths = mLoadedPaths.Where(f => f.AssociatedEmulator == emu.Name);
                foreach(RomPath path in associatedPaths)
                {
                    List<String> resolvedFiles = mPathResolver.ResolvePaths(path.FolderPath,path.RomExtension);
                    foreach(String file in resolvedFiles)
                    {
                        emulatorNode.Nodes.Add(file);
                    }
                }

                rootNode.Nodes.Add(emulatorNode);
            }
        }

        private void modifyEmulators_Click(object sender, EventArgs e)
        {
            using (AddNewEmulator mModifyEmulatorsForm = new AddNewEmulator())
            {
                mModifyEmulatorsForm.Initialize(mLoadedEmulators.Select(f => f.Name).ToList());
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
            if(mLoadedEmulators.Count == 0)
            {
                String err = "Cannot add a new path as no emulators have been defined in the current configuration! Add a new emulator first.";
                mLogger.Warn(err);
                MessageBox.Show(this, err, "Error");
            }
            else
            {
                using (AddNewPath mModifyPathsForm = new AddNewPath())
                {
                    mLogger.Info("ModifyPaths clicked, displaying form");

                    var loadedEmulators = mLoadedEmulators.Select(f => f.Name).ToArray();
                    mModifyPathsForm.Initialize(loadedEmulators);
                    if (mModifyPathsForm.ShowDialog(this) == DialogResult.OK)
                    {
                        String path = mModifyPathsForm.RomPath;
                        String associatedEmulator = mModifyPathsForm.EmulatorToUse;
                        String extension = mModifyPathsForm.EmulatorExtension;
                        mConfigurationComponent.AddRomPath(path, associatedEmulator,extension);
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
            if(CurrentCommand.IsValidCommand)
            {
                String command = CurrentCommand.ToString();
                mLogger.Info(String.Format("Attempting to execute command {0}", command));
                mExecutionComponent.ExecuteCommand(CurrentCommand);
            }
            else
            {
                mLogger.Info("No Path selected");
            }
        }

        private void treeEmulatorView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            mLogger.Info(String.Format("Selected Node: {0} at level {1}",selectedNode.FullPath, selectedNode.Level));

            if(selectedNode.Level == 2)
            {
                // User selected a node corresponding to a path
                String emulatorName = selectedNode.Parent.Text;
                Emulator emu = mLoadedEmulators.First(f => f.Name == emulatorName);
                String path = selectedNode.Text;
                mLogger.Debug(String.Format("Selected node is a Path node corresponding to emulator <{0}>",emu.ToString()));

                CurrentCommand = new Command(emu.Path, emu.Arguments, path);
                mLogger.Info(String.Format("Completed command line: {0}", CurrentCommand.ToString()));
            }
            else
            {
                mLogger.Debug("Selected node is not a Path node, clearing command line");
                CurrentCommand = new Command();
            }
        }

        private void refreshViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redrawTreeView();
        }

        private void treeEmulatorView_Click(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Right click handler for tree emulator
            if(e.Button == MouseButtons.Right)
            {
                TreeNode selectedNode = treeEmulatorView.GetNodeAt(e.Location);
                mLogger.Debug(String.Format("RightClicked node {0}", selectedNode.FullPath));

                switch(selectedNode.Level)
                {
                    case 0: // root
                        HandleRootRightClick();
                        break;
                    case 1: // emulator
                        break;
                    case 2: // path
                        break;
                }
            }
        }

        private void HandleRootRightClick()
        {
            mLogger.Debug("Handling root node right click");
            ContextMenuStrip ctxMenu = new ContextMenuStrip();
            ToolStripMenuItem newEmulator = new ToolStripMenuItem("Add New Emulator");
            newEmulator.Click += modifyEmulators_Click;

            ctxMenu.Items.Add(newEmulator);
            treeEmulatorView.ContextMenuStrip = ctxMenu;
        }
    }
}
