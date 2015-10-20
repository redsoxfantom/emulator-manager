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
            this.managerConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modfyEmulatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeEmulatorView = new System.Windows.Forms.TreeView();
            this.lblCommandToExecute = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.loadToolStripMenuItem.Text = "Load Manager Config";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.saveToolStripMenuItem.Text = "Save Manager Config";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
            this.treeEmulatorView.Location = new System.Drawing.Point(13, 28);
            this.treeEmulatorView.Name = "treeEmulatorView";
            this.treeEmulatorView.Size = new System.Drawing.Size(825, 600);
            this.treeEmulatorView.TabIndex = 1;
            // 
            // lblCommandToExecute
            // 
            this.lblCommandToExecute.AutoSize = true;
            this.lblCommandToExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommandToExecute.Location = new System.Drawing.Point(13, 635);
            this.lblCommandToExecute.Name = "lblCommandToExecute";
            this.lblCommandToExecute.Size = new System.Drawing.Size(75, 17);
            this.lblCommandToExecute.TabIndex = 2;
            this.lblCommandToExecute.Text = "Command:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 635);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(743, 20);
            this.textBox1.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 675);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
    }
}