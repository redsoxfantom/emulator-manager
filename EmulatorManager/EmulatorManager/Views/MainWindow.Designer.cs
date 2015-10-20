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
            this.modfyEmulatorsToolStripMenuItem.Click += new System.EventHandler(this.modfyEmulators_Click);
            // 
            // modifyPathsToolStripMenuItem
            // 
            this.modifyPathsToolStripMenuItem.Name = "modifyPathsToolStripMenuItem";
            this.modifyPathsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.modifyPathsToolStripMenuItem.Text = "Modify Paths";
            this.modifyPathsToolStripMenuItem.Click += new System.EventHandler(this.modifyPaths_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 675);
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
    }
}