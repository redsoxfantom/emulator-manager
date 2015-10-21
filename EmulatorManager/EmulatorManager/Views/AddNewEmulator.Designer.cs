namespace EmulatorManager.Views
{
    partial class AddNewEmulator
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
            this.txtEmulatorPath = new System.Windows.Forms.TextBox();
            this.lblSelectEmulator = new System.Windows.Forms.Label();
            this.btnEmulatorBrowse = new System.Windows.Forms.Button();
            this.lblEmulatorOptions = new System.Windows.Forms.Label();
            this.txtEmulatorArguments = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnEmulatorArgumentHelp = new System.Windows.Forms.Button();
            this.btnEmulatorNameHelp = new System.Windows.Forms.Button();
            this.txtEmulatorName = new System.Windows.Forms.TextBox();
            this.lblEmulatorName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmulatorPath
            // 
            this.txtEmulatorPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmulatorPath.Location = new System.Drawing.Point(12, 26);
            this.txtEmulatorPath.Name = "txtEmulatorPath";
            this.txtEmulatorPath.Size = new System.Drawing.Size(315, 23);
            this.txtEmulatorPath.TabIndex = 0;
            // 
            // lblSelectEmulator
            // 
            this.lblSelectEmulator.AutoSize = true;
            this.lblSelectEmulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectEmulator.Location = new System.Drawing.Point(9, 6);
            this.lblSelectEmulator.Name = "lblSelectEmulator";
            this.lblSelectEmulator.Size = new System.Drawing.Size(101, 17);
            this.lblSelectEmulator.TabIndex = 1;
            this.lblSelectEmulator.Text = "Emulator Path:";
            // 
            // btnEmulatorBrowse
            // 
            this.btnEmulatorBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmulatorBrowse.Location = new System.Drawing.Point(333, 26);
            this.btnEmulatorBrowse.Name = "btnEmulatorBrowse";
            this.btnEmulatorBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnEmulatorBrowse.TabIndex = 2;
            this.btnEmulatorBrowse.Text = "Browse...";
            this.btnEmulatorBrowse.UseVisualStyleBackColor = true;
            this.btnEmulatorBrowse.Click += new System.EventHandler(this.btnEmulatorBrowse_Click);
            // 
            // lblEmulatorOptions
            // 
            this.lblEmulatorOptions.AutoSize = true;
            this.lblEmulatorOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmulatorOptions.Location = new System.Drawing.Point(9, 56);
            this.lblEmulatorOptions.Name = "lblEmulatorOptions";
            this.lblEmulatorOptions.Size = new System.Drawing.Size(140, 17);
            this.lblEmulatorOptions.TabIndex = 3;
            this.lblEmulatorOptions.Text = "Emulator Arguments:";
            // 
            // txtEmulatorArguments
            // 
            this.txtEmulatorArguments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmulatorArguments.Location = new System.Drawing.Point(12, 76);
            this.txtEmulatorArguments.Name = "txtEmulatorArguments";
            this.txtEmulatorArguments.Size = new System.Drawing.Size(315, 23);
            this.txtEmulatorArguments.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(172, 156);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 27);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnEmulatorArgumentHelp
            // 
            this.btnEmulatorArgumentHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmulatorArgumentHelp.Location = new System.Drawing.Point(333, 75);
            this.btnEmulatorArgumentHelp.Name = "btnEmulatorArgumentHelp";
            this.btnEmulatorArgumentHelp.Size = new System.Drawing.Size(21, 23);
            this.btnEmulatorArgumentHelp.TabIndex = 6;
            this.btnEmulatorArgumentHelp.Text = "?";
            this.btnEmulatorArgumentHelp.UseVisualStyleBackColor = true;
            this.btnEmulatorArgumentHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnEmulatorNameHelp
            // 
            this.btnEmulatorNameHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmulatorNameHelp.Location = new System.Drawing.Point(333, 126);
            this.btnEmulatorNameHelp.Name = "btnEmulatorNameHelp";
            this.btnEmulatorNameHelp.Size = new System.Drawing.Size(21, 23);
            this.btnEmulatorNameHelp.TabIndex = 9;
            this.btnEmulatorNameHelp.Text = "?";
            this.btnEmulatorNameHelp.UseVisualStyleBackColor = true;
            this.btnEmulatorNameHelp.Click += new System.EventHandler(this.btnEmulatorNameHelp_Click);
            // 
            // txtEmulatorName
            // 
            this.txtEmulatorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmulatorName.Location = new System.Drawing.Point(12, 127);
            this.txtEmulatorName.Name = "txtEmulatorName";
            this.txtEmulatorName.Size = new System.Drawing.Size(315, 23);
            this.txtEmulatorName.TabIndex = 8;
            // 
            // lblEmulatorName
            // 
            this.lblEmulatorName.AutoSize = true;
            this.lblEmulatorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmulatorName.Location = new System.Drawing.Point(9, 107);
            this.lblEmulatorName.Name = "lblEmulatorName";
            this.lblEmulatorName.Size = new System.Drawing.Size(109, 17);
            this.lblEmulatorName.TabIndex = 7;
            this.lblEmulatorName.Text = "Emulator Name:";
            // 
            // AddNewEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 195);
            this.Controls.Add(this.btnEmulatorNameHelp);
            this.Controls.Add(this.txtEmulatorName);
            this.Controls.Add(this.lblEmulatorName);
            this.Controls.Add(this.btnEmulatorArgumentHelp);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtEmulatorArguments);
            this.Controls.Add(this.lblEmulatorOptions);
            this.Controls.Add(this.btnEmulatorBrowse);
            this.Controls.Add(this.lblSelectEmulator);
            this.Controls.Add(this.txtEmulatorPath);
            this.Name = "AddNewEmulator";
            this.Text = "Add New Emulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmulatorPath;
        private System.Windows.Forms.Label lblSelectEmulator;
        private System.Windows.Forms.Button btnEmulatorBrowse;
        private System.Windows.Forms.Label lblEmulatorOptions;
        private System.Windows.Forms.TextBox txtEmulatorArguments;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnEmulatorArgumentHelp;
        private System.Windows.Forms.Button btnEmulatorNameHelp;
        private System.Windows.Forms.TextBox txtEmulatorName;
        private System.Windows.Forms.Label lblEmulatorName;
    }
}