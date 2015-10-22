namespace EmulatorManager.Views
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modfyEmulatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeEmulatorView = new System.Windows.Forms.TreeView();
            this.lblCommandToExecute = new System.Windows.Forms.Label();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.btnExecuteEmulator = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.managerConfigToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.refreshViewToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // refreshViewToolStripMenuItem
            // 
            this.refreshViewToolStripMenuItem.Name = "refreshViewToolStripMenuItem";
            this.refreshViewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshViewToolStripMenuItem.Text = "Refresh";
            this.refreshViewToolStripMenuItem.Click += new System.EventHandler(this.refreshViewToolStripMenuItem_Click);
            // 
            // managerConfigToolStripMenuItem
            // 
            this.managerConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modfyEmulatorsToolStripMenuItem,
            this.modifyPathsToolStripMenuItem});
            this.managerConfigToolStripMenuItem.Name = "managerConfigToolStripMenuItem";
            this.managerConfigToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.managerConfigToolStripMenuItem.Text = "*EMPTY*";
            // 
            // modfyEmulatorsToolStripMenuItem
            // 
            this.modfyEmulatorsToolStripMenuItem.Name = "modfyEmulatorsToolStripMenuItem";
            this.modfyEmulatorsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.modfyEmulatorsToolStripMenuItem.Text = "Modify Emulators";
            this.modfyEmulatorsToolStripMenuItem.Click += new System.EventHandler(this.modifyEmulators_Click);
            // 
            // modifyPathsToolStripMenuItem
            // 
            this.modifyPathsToolStripMenuItem.Name = "modifyPathsToolStripMenuItem";
            this.modifyPathsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.modifyPathsToolStripMenuItem.Text = "Modify Paths";
            this.modifyPathsToolStripMenuItem.Click += new System.EventHandler(this.modifyPaths_Click);
            // 
            // treeEmulatorView
            // 
            this.treeEmulatorView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeEmulatorView.Location = new System.Drawing.Point(13, 28);
            this.treeEmulatorView.Name = "treeEmulatorView";
            this.treeEmulatorView.PathSeparator = ">";
            this.treeEmulatorView.Size = new System.Drawing.Size(825, 600);
            this.treeEmulatorView.TabIndex = 1;
            this.treeEmulatorView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEmulatorView_AfterSelect);
            // 
            // lblCommandToExecute
            // 
            this.lblCommandToExecute.AutoSize = true;
            this.lblCommandToExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommandToExecute.Location = new System.Drawing.Point(14, 657);
            this.lblCommandToExecute.Name = "lblCommandToExecute";
            this.lblCommandToExecute.Size = new System.Drawing.Size(75, 17);
            this.lblCommandToExecute.TabIndex = 2;
            this.lblCommandToExecute.Text = "Command:";
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Enabled = false;
            this.txtCommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommandLine.Location = new System.Drawing.Point(95, 635);
            this.txtCommandLine.Multiline = true;
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(743, 63);
            this.txtCommandLine.TabIndex = 3;
            // 
            // btnExecuteEmulator
            // 
            this.btnExecuteEmulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteEmulator.Location = new System.Drawing.Point(350, 704);
            this.btnExecuteEmulator.Name = "btnExecuteEmulator";
            this.btnExecuteEmulator.Size = new System.Drawing.Size(150, 26);
            this.btnExecuteEmulator.TabIndex = 4;
            this.btnExecuteEmulator.Text = "Begin Emulator";
            this.btnExecuteEmulator.UseVisualStyleBackColor = true;
            this.btnExecuteEmulator.Click += new System.EventHandler(this.btnExecuteEmulator_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 742);
            this.Controls.Add(this.btnExecuteEmulator);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.lblCommandToExecute);
            this.Controls.Add(this.treeEmulatorView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Emulator Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managerConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modfyEmulatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyPathsToolStripMenuItem;
        private System.Windows.Forms.TreeView treeEmulatorView;
        private System.Windows.Forms.Label lblCommandToExecute;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Button btnExecuteEmulator;
        private System.Windows.Forms.ToolStripMenuItem refreshViewToolStripMenuItem;
    }
}