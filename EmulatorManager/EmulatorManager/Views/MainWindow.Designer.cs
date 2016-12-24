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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeEmulatorView = new System.Windows.Forms.TreeView();
            this.lblCommandToExecute = new System.Windows.Forms.Label();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.btnExecuteEmulator = new System.Windows.Forms.Button();
            this.imgGameImage = new System.Windows.Forms.Panel();
            this.lblGameInfo = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblGamePublisher = new System.Windows.Forms.Label();
            this.lblGameSystem = new System.Windows.Forms.Label();
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GameDataTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblGameTimePlayed = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblClickHere = new System.Windows.Forms.LinkLabel();
            this.lblDataMissing = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.MainTableLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GameDataTableLayout.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1437, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // refreshViewToolStripMenuItem
            // 
            this.refreshViewToolStripMenuItem.Name = "refreshViewToolStripMenuItem";
            this.refreshViewToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.refreshViewToolStripMenuItem.Text = "Refresh";
            this.refreshViewToolStripMenuItem.Click += new System.EventHandler(this.refreshViewToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controllerToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // controllerToolStripMenuItem
            // 
            this.controllerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConfigToolStripMenuItem,
            this.loadConfigToolStripMenuItem});
            this.controllerToolStripMenuItem.Name = "controllerToolStripMenuItem";
            this.controllerToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.controllerToolStripMenuItem.Text = "Controller";
            // 
            // newConfigToolStripMenuItem
            // 
            this.newConfigToolStripMenuItem.Name = "newConfigToolStripMenuItem";
            this.newConfigToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.newConfigToolStripMenuItem.Text = "New Config";
            this.newConfigToolStripMenuItem.Click += new System.EventHandler(this.newConfigToolStripMenuItem_Click);
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.loadConfigToolStripMenuItem.Text = "Load Config";
            // 
            // treeEmulatorView
            // 
            this.treeEmulatorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeEmulatorView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeEmulatorView.HideSelection = false;
            this.treeEmulatorView.Location = new System.Drawing.Point(4, 4);
            this.treeEmulatorView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeEmulatorView.Name = "treeEmulatorView";
            this.treeEmulatorView.PathSeparator = ">";
            this.treeEmulatorView.Size = new System.Drawing.Size(997, 722);
            this.treeEmulatorView.TabIndex = 1;
            this.treeEmulatorView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEmulatorView_AfterSelect);
            this.treeEmulatorView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeEmulatorView_Click);
            this.treeEmulatorView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeEmulatorView_ClearMenu);
            // 
            // lblCommandToExecute
            // 
            this.lblCommandToExecute.AutoSize = true;
            this.lblCommandToExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommandToExecute.Location = new System.Drawing.Point(4, 0);
            this.lblCommandToExecute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommandToExecute.Name = "lblCommandToExecute";
            this.lblCommandToExecute.Size = new System.Drawing.Size(90, 20);
            this.lblCommandToExecute.TabIndex = 2;
            this.lblCommandToExecute.Text = "Command:";
            this.lblCommandToExecute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommandLine.Location = new System.Drawing.Point(117, 4);
            this.txtCommandLine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCommandLine.Multiline = true;
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.ReadOnly = true;
            this.txtCommandLine.Size = new System.Drawing.Size(876, 84);
            this.txtCommandLine.TabIndex = 3;
            // 
            // btnExecuteEmulator
            // 
            this.btnExecuteEmulator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecuteEmulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteEmulator.Location = new System.Drawing.Point(117, 96);
            this.btnExecuteEmulator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExecuteEmulator.Name = "btnExecuteEmulator";
            this.btnExecuteEmulator.Size = new System.Drawing.Size(876, 46);
            this.btnExecuteEmulator.TabIndex = 4;
            this.btnExecuteEmulator.Text = "Begin Emulator";
            this.btnExecuteEmulator.UseVisualStyleBackColor = true;
            this.btnExecuteEmulator.Click += new System.EventHandler(this.btnExecuteEmulator_Click);
            // 
            // imgGameImage
            // 
            this.imgGameImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgGameImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgGameImage.Location = new System.Drawing.Point(4, 29);
            this.imgGameImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgGameImage.Name = "imgGameImage";
            this.imgGameImage.Size = new System.Drawing.Size(416, 468);
            this.imgGameImage.TabIndex = 5;
            // 
            // lblGameInfo
            // 
            this.lblGameInfo.AutoSize = true;
            this.lblGameInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameInfo.Location = new System.Drawing.Point(4, 0);
            this.lblGameInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameInfo.Name = "lblGameInfo";
            this.lblGameInfo.Size = new System.Drawing.Size(416, 25);
            this.lblGameInfo.TabIndex = 6;
            this.lblGameInfo.Text = "Game Data";
            this.lblGameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameName
            // 
            this.lblGameName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.Location = new System.Drawing.Point(4, 501);
            this.lblGameName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(416, 49);
            this.lblGameName.TabIndex = 7;
            this.lblGameName.Text = "Game Name";
            this.lblGameName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGameName.UseCompatibleTextRendering = true;
            // 
            // lblGamePublisher
            // 
            this.lblGamePublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGamePublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamePublisher.Location = new System.Drawing.Point(4, 550);
            this.lblGamePublisher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGamePublisher.Name = "lblGamePublisher";
            this.lblGamePublisher.Size = new System.Drawing.Size(416, 49);
            this.lblGamePublisher.TabIndex = 8;
            this.lblGamePublisher.Text = "Game Publisher";
            this.lblGamePublisher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameSystem
            // 
            this.lblGameSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGameSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameSystem.Location = new System.Drawing.Point(4, 599);
            this.lblGameSystem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameSystem.Name = "lblGameSystem";
            this.lblGameSystem.Size = new System.Drawing.Size(416, 49);
            this.lblGameSystem.TabIndex = 9;
            this.lblGameSystem.Text = "Game System";
            this.lblGameSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 2;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTableLayout.Controls.Add(this.treeEmulatorView, 0, 0);
            this.MainTableLayout.Controls.Add(this.panel1, 1, 0);
            this.MainTableLayout.Controls.Add(this.panel2, 0, 1);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 28);
            this.MainTableLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 2;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.MainTableLayout.Size = new System.Drawing.Size(1437, 884);
            this.MainTableLayout.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GameDataTableLayout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1009, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 722);
            this.panel1.TabIndex = 2;
            // 
            // GameDataTableLayout
            // 
            this.GameDataTableLayout.ColumnCount = 1;
            this.GameDataTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GameDataTableLayout.Controls.Add(this.lblGameTimePlayed, 0, 5);
            this.GameDataTableLayout.Controls.Add(this.imgGameImage, 0, 1);
            this.GameDataTableLayout.Controls.Add(this.lblGameInfo, 0, 0);
            this.GameDataTableLayout.Controls.Add(this.lblGameSystem, 0, 4);
            this.GameDataTableLayout.Controls.Add(this.lblGameName, 0, 2);
            this.GameDataTableLayout.Controls.Add(this.lblGamePublisher, 0, 3);
            this.GameDataTableLayout.Controls.Add(this.tableLayoutPanel4, 0, 6);
            this.GameDataTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameDataTableLayout.Location = new System.Drawing.Point(0, 0);
            this.GameDataTableLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GameDataTableLayout.Name = "GameDataTableLayout";
            this.GameDataTableLayout.RowCount = 7;
            this.GameDataTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.GameDataTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GameDataTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.GameDataTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.GameDataTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.GameDataTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.GameDataTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.GameDataTableLayout.Size = new System.Drawing.Size(424, 722);
            this.GameDataTableLayout.TabIndex = 12;
            // 
            // lblGameTimePlayed
            // 
            this.lblGameTimePlayed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGameTimePlayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameTimePlayed.Location = new System.Drawing.Point(4, 648);
            this.lblGameTimePlayed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameTimePlayed.Name = "lblGameTimePlayed";
            this.lblGameTimePlayed.Size = new System.Drawing.Size(416, 49);
            this.lblGameTimePlayed.TabIndex = 11;
            this.lblGameTimePlayed.Text = "Time Played";
            this.lblGameTimePlayed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel4.Controls.Add(this.lblClickHere, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblDataMissing, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 701);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(416, 17);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // lblClickHere
            // 
            this.lblClickHere.AutoSize = true;
            this.lblClickHere.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblClickHere.Location = new System.Drawing.Point(264, 0);
            this.lblClickHere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClickHere.Name = "lblClickHere";
            this.lblClickHere.Size = new System.Drawing.Size(72, 17);
            this.lblClickHere.TabIndex = 15;
            this.lblClickHere.TabStop = true;
            this.lblClickHere.Text = "Click Here";
            this.lblClickHere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClickHere.Visible = false;
            this.lblClickHere.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClickHere_LinkClicked);
            // 
            // lblDataMissing
            // 
            this.lblDataMissing.AutoSize = true;
            this.lblDataMissing.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDataMissing.Location = new System.Drawing.Point(79, 0);
            this.lblDataMissing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataMissing.Name = "lblDataMissing";
            this.lblDataMissing.Size = new System.Drawing.Size(177, 17);
            this.lblDataMissing.TabIndex = 14;
            this.lblDataMissing.Text = "Data incomplete or wrong?";
            this.lblDataMissing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDataMissing.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 734);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 146);
            this.panel2.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnExecuteEmulator, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCommandLine, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCommandToExecute, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(997, 146);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 912);
            this.Controls.Add(this.MainTableLayout);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.Text = "Emulator Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_OnClose);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainTableLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.GameDataTableLayout.ResumeLayout(false);
            this.GameDataTableLayout.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel GameDataTableLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.LinkLabel lblClickHere;
        private System.Windows.Forms.Label lblDataMissing;
        private System.Windows.Forms.Label lblGameTimePlayed;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
    }
}