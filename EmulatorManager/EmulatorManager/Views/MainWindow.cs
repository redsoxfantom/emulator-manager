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
                                "Info",
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

            ctxMenu.Items.Add(modifyEmulator);
            ctxMenu.Items.Add(addNewPath);
            treeEmulatorView.ContextMenuStrip = ctxMenu;
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
                mLogger.Info("ModifyEmulators clicked, displaying form");
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

            ctxMenu.Items.Add(newEmulator);
            treeEmulatorView.ContextMenuStrip = ctxMenu;
        }

    }
}
