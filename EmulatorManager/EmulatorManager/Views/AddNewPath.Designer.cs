namespace EmulatorManager.Views
{
    partial class AddNewPath
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
            this.lblPathToRomDirectory = new System.Windows.Forms.Label();
            this.txtPathToRomDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblSelectEmulator = new System.Windows.Forms.Label();
            this.cbxSelectedEmulator = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtRomExtension = new System.Windows.Forms.TextBox();
            this.lblRomExtension = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPathToRomDirectory
            // 
            this.lblPathToRomDirectory.AutoSize = true;
            this.lblPathToRomDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathToRomDirectory.Location = new System.Drawing.Point(13, 13);
            this.lblPathToRomDirectory.Name = "lblPathToRomDirectory";
            this.lblPathToRomDirectory.Size = new System.Drawing.Size(156, 17);
            this.lblPathToRomDirectory.TabIndex = 0;
            this.lblPathToRomDirectory.Text = "Path To Rom Directory:";
            // 
            // txtPathToRomDirectory
            // 
            this.txtPathToRomDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathToRomDirectory.Location = new System.Drawing.Point(16, 33);
            this.txtPathToRomDirectory.Name = "txtPathToRomDirectory";
            this.txtPathToRomDirectory.Size = new System.Drawing.Size(364, 23);
            this.txtPathToRomDirectory.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(387, 33);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblSelectEmulator
            // 
            this.lblSelectEmulator.AutoSize = true;
            this.lblSelectEmulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectEmulator.Location = new System.Drawing.Point(13, 66);
            this.lblSelectEmulator.Name = "lblSelectEmulator";
            this.lblSelectEmulator.Size = new System.Drawing.Size(111, 17);
            this.lblSelectEmulator.TabIndex = 3;
            this.lblSelectEmulator.Text = "Select Emulator:";
            // 
            // cbxSelectedEmulator
            // 
            this.cbxSelectedEmulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSelectedEmulator.FormattingEnabled = true;
            this.cbxSelectedEmulator.Location = new System.Drawing.Point(131, 63);
            this.cbxSelectedEmulator.Name = "cbxSelectedEmulator";
            this.cbxSelectedEmulator.Size = new System.Drawing.Size(249, 24);
            this.cbxSelectedEmulator.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(204, 132);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 27);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtRomExtension
            // 
            this.txtRomExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRomExtension.Location = new System.Drawing.Point(151, 93);
            this.txtRomExtension.Name = "txtRomExtension";
            this.txtRomExtension.Size = new System.Drawing.Size(229, 23);
            this.txtRomExtension.TabIndex = 6;
            // 
            // lblRomExtension
            // 
            this.lblRomExtension.AutoSize = true;
            this.lblRomExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRomExtension.Location = new System.Drawing.Point(13, 96);
            this.lblRomExtension.Name = "lblRomExtension";
            this.lblRomExtension.Size = new System.Drawing.Size(132, 17);
            this.lblRomExtension.TabIndex = 7;
            this.lblRomExtension.Text = "Rom File Extension:";
            // 
            // AddNewPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 171);
            this.Controls.Add(this.lblRomExtension);
            this.Controls.Add(this.txtRomExtension);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbxSelectedEmulator);
            this.Controls.Add(this.lblSelectEmulator);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPathToRomDirectory);
            this.Controls.Add(this.lblPathToRomDirectory);
            this.Name = "AddNewPath";
            this.Text = "Add New Rom Path";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPathToRomDirectory;
        private System.Windows.Forms.TextBox txtPathToRomDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSelectEmulator;
        private System.Windows.Forms.ComboBox cbxSelectedEmulator;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtRomExtension;
        private System.Windows.Forms.Label lblRomExtension;
    }
}