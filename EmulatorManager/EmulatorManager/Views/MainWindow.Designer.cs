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
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeEmulatorView = new System.Windows.Forms.TreeView();
            this.lblCommandToExecute = new System.Windows.Forms.Label();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.btnExecuteEmulator = new System.Windows.Forms.Button();
            this.imgGameImage = new System.Windows.Forms.Panel();
            this.lblGameInfo = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblGamePublisher = new System.Windows.Forms.Label();
            this.lblGameSystem = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.refreshViewToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // refreshViewToolStripMenuItem
            // 
            this.refreshViewToolStripMenuItem.Name = "refreshViewToolStripMenuItem";
            this.refreshViewToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.refreshViewToolStripMenuItem.Text = "Refresh";
            this.refreshViewToolStripMenuItem.Click += new System.EventHandler(this.refreshViewToolStripMenuItem_Click);
            // 
            // treeEmulatorView
            // 
            this.treeEmulatorView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeEmulatorView.Location = new System.Drawing.Point(13, 28);
            this.treeEmulatorView.Name = "treeEmulatorView";
            this.treeEmulatorView.PathSeparator = ">";
            this.treeEmulatorView.Size = new System.Drawing.Size(550, 628);
            this.treeEmulatorView.TabIndex = 1;
            this.treeEmulatorView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEmulatorView_AfterSelect);
            this.treeEmulatorView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeEmulatorView_Click);
            this.treeEmulatorView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeEmulatorView_ClearMenu);
            // 
            // lblCommandToExecute
            // 
            this.lblCommandToExecute.AutoSize = true;
            this.lblCommandToExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommandToExecute.Location = new System.Drawing.Point(14, 684);
            this.lblCommandToExecute.Name = "lblCommandToExecute";
            this.lblCommandToExecute.Size = new System.Drawing.Size(75, 17);
            this.lblCommandToExecute.TabIndex = 2;
            this.lblCommandToExecute.Text = "Command:";
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Enabled = false;
            this.txtCommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommandLine.Location = new System.Drawing.Point(95, 662);
            this.txtCommandLine.Multiline = true;
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(657, 63);
            this.txtCommandLine.TabIndex = 3;
            // 
            // btnExecuteEmulator
            // 
            this.btnExecuteEmulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteEmulator.Location = new System.Drawing.Point(350, 731);
            this.btnExecuteEmulator.Name = "btnExecuteEmulator";
            this.btnExecuteEmulator.Size = new System.Drawing.Size(150, 26);
            this.btnExecuteEmulator.TabIndex = 4;
            this.btnExecuteEmulator.Text = "Begin Emulator";
            this.btnExecuteEmulator.UseVisualStyleBackColor = true;
            this.btnExecuteEmulator.Click += new System.EventHandler(this.btnExecuteEmulator_Click);
            // 
            // imgGameImage
            // 
            this.imgGameImage.BackgroundImage = global::EmulatorManager.Properties.Resources.No_Image_Found;
            this.imgGameImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgGameImage.Location = new System.Drawing.Point(569, 48);
            this.imgGameImage.Name = "imgGameImage";
            this.imgGameImage.Size = new System.Drawing.Size(183, 193);
            this.imgGameImage.TabIndex = 5;
            // 
            // lblGameInfo
            // 
            this.lblGameInfo.AutoSize = true;
            this.lblGameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameInfo.Location = new System.Drawing.Point(620, 28);
            this.lblGameInfo.Name = "lblGameInfo";
            this.lblGameInfo.Size = new System.Drawing.Size(80, 17);
            this.lblGameInfo.TabIndex = 6;
            this.lblGameInfo.Text = "Game Data";
            // 
            // lblGameName
            // 
            this.lblGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.Location = new System.Drawing.Point(569, 244);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(183, 71);
            this.lblGameName.TabIndex = 7;
            this.lblGameName.Text = "<GAME NAME>";
            // 
            // lblGamePublisher
            // 
            this.lblGamePublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamePublisher.Location = new System.Drawing.Point(570, 315);
            this.lblGamePublisher.Name = "lblGamePublisher";
            this.lblGamePublisher.Size = new System.Drawing.Size(182, 74);
            this.lblGamePublisher.TabIndex = 8;
            this.lblGamePublisher.Text = "<GAME PUBLISHER>";
            // 
            // lblGameSystem
            // 
            this.lblGameSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameSystem.Location = new System.Drawing.Point(570, 389);
            this.lblGameSystem.Name = "lblGameSystem";
            this.lblGameSystem.Size = new System.Drawing.Size(182, 96);
            this.lblGameSystem.TabIndex = 9;
            this.lblGameSystem.Text = "<GAME SYSTEM>";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 762);
            this.Controls.Add(this.lblGameSystem);
            this.Controls.Add(this.lblGamePublisher);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.lblGameInfo);
            this.Controls.Add(this.imgGameImage);
            this.Controls.Add(this.btnExecuteEmulator);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.lblCommandToExecute);
            this.Controls.Add(this.treeEmulatorView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Emulator Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_OnClose);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.TreeView treeEmulatorView;
        private System.Windows.Forms.Label lblCommandToExecute;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Button btnExecuteEmulator;
        private System.Windows.Forms.ToolStripMenuItem refreshViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Panel imgGameImage;
        private System.Windows.Forms.Label lblGameInfo;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblGamePublisher;
        private System.Windows.Forms.Label lblGameSystem;
    }
}