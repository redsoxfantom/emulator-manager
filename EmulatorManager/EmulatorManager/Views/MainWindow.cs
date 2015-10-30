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
using EmulatorManager.Views.TreeNodes;
using EmulatorManager.Components.GameDataComponent;

namespace EmulatorManager.Views
{
    //https://www.launchbox-app.com/forum/emulation/command-line-parameters-arguments

    public partial class MainWindow : Form
    {
        private ILog mLogger;

        private ConfigComponent mConfigurationComponent;

        private EmulatorExecutionComponent mExecutionComponent;

        private PathResolverComponent mPathResolver;

        private RomDataComponent mRomDataComponent;

        private String mConfigFileName;

        private String mConfigFilePath;

        private bool mConfigIsDirty;

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
            mRomDataComponent = RomDataComponent.Instance;
            mConfigurationComponent.GetCurrentConfig(out mConfigFileName, out mConfigFilePath, out mLoadedEmulators, out mLoadedPaths);
            mExecutionComponent = new EmulatorExecutionComponent();
            mPathResolver = new PathResolverComponent();
            CurrentCommand = new Command();
        }

        public void Initialize()
        {
            mConfigurationComponent.ConfigutationChanged += MEmulatorManager_ConfigutationChanged;
            processConfig();

            mExecutionComponent.ExecutionStateChangeHandler += MExecutionComponent_ExecutionStateChangeHandler;
        }

        private void MExecutionComponent_ExecutionStateChangeHandler(ExecutionStateChangedEventArgs args)
        {
            switch(args.State)
            {
                case ExecutionState.RUNNING:
                    btnExecuteEmulator.Invoke(new Action(()=> { btnExecuteEmulator.Text = "Terminate Emulator"; }));
                    break;
                case ExecutionState.TERMINATED:
                    btnExecuteEmulator.Invoke(new Action(() => { btnExecuteEmulator.Text = "Begin Emulator"; }));
                    break;
            }
        }

        private void processConfig()
        {
            redrawTreeView();
        }

        private void MEmulatorManager_ConfigutationChanged(LoadedConfigChangedArgs args)
        {
            mConfigFileName = args.FileName;
            mLoadedEmulators = args.LoadedEmulators;
            mLoadedPaths = args.LoadedPaths;
            mConfigIsDirty = args.ConfigIsDirty;
            mConfigFilePath = args.FilePath;

            processConfig();
        }

        private string getConfigFilename()
        {
            // return the filename of the loaded config, adding a * if it is dirty
            string configFileName = mConfigFileName;
            if (mConfigIsDirty)
            {
                configFileName += " *";
            }

            return configFileName;
        }

        private void redrawTreeView()
        {
            treeEmulatorView.Nodes.Clear();
            treeEmulatorView.Nodes.Add(getConfigFilename());
            TreeNode rootNode = treeEmulatorView.Nodes[0];
            
            foreach(Emulator emu in mLoadedEmulators)
            {
                TreeNode emulatorNode = new EmulatorTreeNode(emu);

                var associatedPaths = mLoadedPaths.Where(f => f.AssociatedEmulator == emu.Name);
                foreach(RomPath path in associatedPaths)
                {
                    List<String> resolvedFiles = mPathResolver.ResolvePaths(path.FolderPath,path.RomExtension);
                    foreach(String file in resolvedFiles)
                    {
                        emulatorNode.Nodes.Add(new PathTreeNode(file,path));
                    }
                }

                rootNode.Nodes.Add(emulatorNode);
            }
        }

        private void addNewEmulators_Click(object sender, EventArgs e)
        {
            using (EmulatorManagementWindow mNewEmulatorForm = new EmulatorManagementWindow())
            {
                mNewEmulatorForm.Initialize(mLoadedEmulators.Select(f => f.Name).ToList());
                mLogger.Info("ModifyEmulators clicked, displaying form");
                if (mNewEmulatorForm.ShowDialog(this) == DialogResult.OK)
                {
                    String name = mNewEmulatorForm.EmulatorName;
                    String path = mNewEmulatorForm.EmulatorPath;
                    String args = mNewEmulatorForm.EmulatorArgs;
                    mConfigurationComponent.AddOrUpdateEmulator(name, path, args);
                }
            }
        }

        private void addNewPaths_Click(object sender, EventArgs e)
        {
            if(mLoadedEmulators.Count == 0)
            {
                String err = "Cannot add a new path as no emulators have been defined in the current configuration! Add a new emulator first.";
                mLogger.Warn(err);
                MessageBox.Show(this, err, "Error");
            }
            else
            {
                using (RomPathManagementWindow mModifyPathsForm = new RomPathManagementWindow())
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

        private void saveCurrentConfig(String SavePath = null)
        {
            if (SavePath == null)
            {
                SavePath = FileManager.UseFilePicker(FileManager.FilePickerType.SAVE, extensionFilter: "Emulator Manager Files (*.mgr)|*.mgr");
            }

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
            if (!mExecutionComponent.EmulatorIsRunning())
            {
                if(CurrentCommand.IsValidCommand)
                {
                    String command = CurrentCommand.ToString();
                    mLogger.Info(String.Format("Attempting to execute command {0}", command));
                    mExecutionComponent.BeginEmulator(CurrentCommand);
                }
                else
                {
                    string err = "You must select a Path to run before starting an emulator";
                    mLogger.Error(err);
                    MessageBox.Show(this, err, "ERROR");
                }
            }
            else
            {
                mLogger.Info("Emulator is running, attempting to terminate");
                mExecutionComponent.TerminateEmulator();
            }
        }

        private async void treeEmulatorView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            mLogger.Info(String.Format("Selected Node: {0} at level {1}",selectedNode.FullPath, selectedNode.Level));

            SetGameInfoLabels();
            if(selectedNode.Level == 1)
            {
                // user selected a node corresponding to an emulator
                String emulatorName = selectedNode.Text;
                Emulator emu = mLoadedEmulators.First(f => f.Name == emulatorName);
                mLogger.Debug(String.Format("Selected node is an Emulator node for emulator <{0}>",emu.ToString()));
                CurrentCommand = new Command(emu.Path);
            }
            else if(selectedNode.Level == 2)
            {
                // User selected a node corresponding to a path
                String emulatorName = selectedNode.Parent.Text;
                Emulator emu = mLoadedEmulators.First(f => f.Name == emulatorName);
                String path = selectedNode.Text;
                mLogger.Debug(String.Format("Selected node is a Path node corresponding to emulator <{0}>",emu.ToString()));

                // Create the command line for this rom
                CurrentCommand = new Command(emu.Path, emu.Arguments, path);
                mLogger.Info(String.Format("Completed command line: {0}", CurrentCommand.ToString()));

                // Query the server (if rom could be read) for the rom details
                string romId = null;
                string romSystem = null;
                SetGameInfoLabels("Fetching Game Info");
                if(mRomDataComponent.TryLoadRomData(path,out romId, out romSystem))
                {
                    GameData data = await mRomDataComponent.RetrieveGameData(romId, romSystem);
                    SetGameInfoLabels(data.GameName, data.GamePublisher, data.GameSystem, data.GameImage,true);
                }
                else
                {
                    SetGameInfoLabels("Rom Could Not Be Parsed");
                }
            }
            else
            {
                mLogger.Debug("Selected node is not a Path or Emulator node, clearing command line");
                CurrentCommand = new Command();
            }
        }

        private void SetGameInfoLabels(string gameName = "", string gamePub = "", string gameSys = "", Image gameImg = null, bool activateUpdateLink = false)
        {
            lblGameName.Text = gameName;
            lblGamePublisher.Text = gamePub;
            lblGameSystem.Text = gameSys;
            imgGameImage.BackgroundImage = gameImg;

            lblClickHere.Visible = activateUpdateLink;
            lblDataMissing.Visible = activateUpdateLink;
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
                mLogger.Debug(String.Format("RightClicked node {0}", e.Node.FullPath));

                switch(e.Node.Level)
                {
                    case 0: // root
                        HandleRootRightClick();
                        break;
                    case 1: // emulator
                        HandleEmulatorRightClick((EmulatorTreeNode)e.Node);
                        break;
                    case 2: // path
                        HandlePathRightClick((PathTreeNode)e.Node);
                        break;
                }

                treeEmulatorView.SelectedNode = e.Node;
            }
        }
        private void treeEmulatorView_ClearMenu(object sender, MouseEventArgs e)
        {
            mLogger.Info("TreeListView click - clearing menu");
            treeEmulatorView.ContextMenuStrip = new ContextMenuStrip();
        }

        private void HandlePathRightClick(PathTreeNode node)
        {
            mLogger.Info("Handling path right click");
            ContextMenuStrip ctxMenu = new ContextMenuStrip();
            ToolStripMenuItem deletePath = new ToolStripMenuItem("Delete Path");
            deletePath.Click += (sender, args) => deletePath_Click(node.RomPath, null);

            ctxMenu.Items.Add(deletePath);
            treeEmulatorView.ContextMenuStrip = ctxMenu;
        }

        private void deletePath_Click(RomPath romPath, object p)
        {
            List<String> PathsThatWillBeDeleted = mPathResolver.ResolvePaths(romPath.FolderPath, romPath.RomExtension);
            String joinedPaths = String.Join("\n", PathsThatWillBeDeleted.ToArray());
            DialogResult res = MessageBox.Show(this, 
                                String.Format("WARNING: The following Roms will no longer be available to the emulator manager:\n{0}", joinedPaths), 
                                "CAUTION",
                                MessageBoxButtons.OKCancel);

            if(res == DialogResult.OK)
            {
                mLogger.Info(String.Format("Deleting path {0}", romPath.FolderPath));
                mConfigurationComponent.RemoveRomPath(romPath.Id);
            }
        }

        private void HandleEmulatorRightClick(EmulatorTreeNode selectedNode)
        {
            Emulator emu = selectedNode.Emulator;
            mLogger.Info(String.Format("Handling emulator right click on emulator {0}", emu.ToString()));
            ContextMenuStrip ctxMenu = new ContextMenuStrip();
            ToolStripMenuItem modifyEmulator = new ToolStripMenuItem(String.Format("Modify {0}",emu.Name));
            modifyEmulator.Click += (sender, args) => ModifyEmulator_Click(selectedNode, null);
            ToolStripMenuItem addNewPath = new ToolStripMenuItem(String.Format("Add New Rom Path To {0}", emu.Name));
            addNewPath.Click += (sender, args) => AddNewPathToEmulator_Click(selectedNode, null);
            ToolStripMenuItem deleteEmulator = new ToolStripMenuItem(String.Format("Delete {0}", emu.Name));
            deleteEmulator.Click += (sender, args) => DeleteEmulator_Click(selectedNode.Emulator, null);

            ctxMenu.Items.Add(modifyEmulator);
            ctxMenu.Items.Add(addNewPath);
            ctxMenu.Items.Add(deleteEmulator);
            treeEmulatorView.ContextMenuStrip = ctxMenu;
        }

        private void DeleteEmulator_Click(Emulator emulator, object p)
        {
            String warning = String.Format("Are you sure you want to remove {0} from the emulator manager?", emulator.Name);
            DialogResult res = MessageBox.Show(this, warning, "CAUTION",MessageBoxButtons.OKCancel);

            if(res == DialogResult.OK)
            {
                mLogger.Info(String.Format("Removing emulator {0}", emulator.Name));
                mConfigurationComponent.RemoveEmulator(emulator.Id);
            }
        }

        private void AddNewPathToEmulator_Click(EmulatorTreeNode selectedNode, object p)
        {
            Emulator selectedEmulator = selectedNode.Emulator;
            
            using (RomPathManagementWindow mModifyPathsForm = new RomPathManagementWindow())
            {
                mModifyPathsForm.Initialize(selectedEmulator.Name);
                if (mModifyPathsForm.ShowDialog(this) == DialogResult.OK)
                {
                    String path = mModifyPathsForm.RomPath;
                    String associatedEmulator = mModifyPathsForm.EmulatorToUse;
                    String extension = mModifyPathsForm.EmulatorExtension;
                    mConfigurationComponent.AddRomPath(path, associatedEmulator, extension);
                }
            }
        }

        private void ModifyEmulator_Click(object sender, EventArgs e)
        {
            Emulator selectedEmulator = ((EmulatorTreeNode)sender).Emulator;

            using (EmulatorManagementWindow mNewEmulatorForm = new EmulatorManagementWindow())
            {
                var loadedEmulators = mLoadedEmulators.Select(f => f.Name).ToList();
                loadedEmulators.Remove(selectedEmulator.Name); // Allow the user to use this emulator's name again
                mNewEmulatorForm.Initialize(loadedEmulators,selectedEmulator.Name,selectedEmulator.Path, selectedEmulator.Arguments);
                if (mNewEmulatorForm.ShowDialog(this) == DialogResult.OK)
                {
                    String name = mNewEmulatorForm.EmulatorName;
                    String path = mNewEmulatorForm.EmulatorPath;
                    String args = mNewEmulatorForm.EmulatorArgs;
                    mConfigurationComponent.AddOrUpdateEmulator(name, path, args,selectedEmulator.Id);
                }
            }
        }

        private void HandleRootRightClick()
        {
            mLogger.Debug("Handling root node right click");
            ContextMenuStrip ctxMenu = new ContextMenuStrip();
            ToolStripMenuItem newEmulator = new ToolStripMenuItem("Add New Emulator");
            newEmulator.Click += addNewEmulators_Click;
            ToolStripMenuItem newPath = new ToolStripMenuItem("Add New Path");
            newPath.Click += addNewPaths_Click;

            ctxMenu.Items.Add(newEmulator);
            ctxMenu.Items.Add(newPath);
            treeEmulatorView.ContextMenuStrip = ctxMenu;
        }

        private void MainWindow_OnClose(object sender, FormClosingEventArgs e)
        {
            if(mConfigIsDirty)
            {
                DialogResult res = MessageBox.Show(this, "Would you like to save the currently loaded manager config?", "Info", MessageBoxButtons.YesNo);
                if(res == DialogResult.Yes)
                {
                    saveCurrentConfig();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCurrentConfig();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCurrentConfig(mConfigFilePath);
        }

        private void lblClickHere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
