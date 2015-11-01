namespace EmulatorManager.Views
{
    partial class UpdateRomDataServerWindow
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
            this.pnlImage = new System.Windows.Forms.Panel();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblGamePublisher = new System.Windows.Forms.Label();
            this.lblGameSystem = new System.Windows.Forms.Label();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.txtGamePublisher = new System.Windows.Forms.TextBox();
            this.txtGameSystem = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.Location = new System.Drawing.Point(12, 42);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(191, 183);
            this.pnlImage.TabIndex = 0;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.Location = new System.Drawing.Point(13, 13);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(192, 17);
            this.lblImage.TabIndex = 1;
            this.lblImage.Text = "Game Image (Click to modify)";
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.Location = new System.Drawing.Point(209, 42);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(91, 17);
            this.lblGameName.TabIndex = 2;
            this.lblGameName.Text = "Game Name:";
            // 
            // lblGamePublisher
            // 
            this.lblGamePublisher.AutoSize = true;
            this.lblGamePublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamePublisher.Location = new System.Drawing.Point(209, 69);
            this.lblGamePublisher.Name = "lblGamePublisher";
            this.lblGamePublisher.Size = new System.Drawing.Size(113, 17);
            this.lblGamePublisher.TabIndex = 3;
            this.lblGamePublisher.Text = "Game Publisher:";
            // 
            // lblGameSystem
            // 
            this.lblGameSystem.AutoSize = true;
            this.lblGameSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameSystem.Location = new System.Drawing.Point(209, 98);
            this.lblGameSystem.Name = "lblGameSystem";
            this.lblGameSystem.Size = new System.Drawing.Size(100, 17);
            this.lblGameSystem.TabIndex = 4;
            this.lblGameSystem.Text = "Game System:";
            // 
            // txtGameName
            // 
            this.txtGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameName.Location = new System.Drawing.Point(328, 39);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(252, 23);
            this.txtGameName.TabIndex = 5;
            // 
            // txtGamePublisher
            // 
            this.txtGamePublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGamePublisher.Location = new System.Drawing.Point(328, 66);
            this.txtGamePublisher.Name = "txtGamePublisher";
            this.txtGamePublisher.Size = new System.Drawing.Size(252, 23);
            this.txtGamePublisher.TabIndex = 6;
            // 
            // txtGameSystem
            // 
            this.txtGameSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameSystem.Location = new System.Drawing.Point(328, 95);
            this.txtGameSystem.Name = "txtGameSystem";
            this.txtGameSystem.Size = new System.Drawing.Size(252, 23);
            this.txtGameSystem.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(250, 226);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 24);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // UpdateRomDataServerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 262);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtGameSystem);
            this.Controls.Add(this.txtGamePublisher);
            this.Controls.Add(this.txtGameName);
            this.Controls.Add(this.lblGameSystem);
            this.Controls.Add(this.lblGamePublisher);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.pnlImage);
            this.Name = "UpdateRomDataServerWindow";
            this.Text = "Add / Update Rom Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblGamePublisher;
        private System.Windows.Forms.Label lblGameSystem;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.TextBox txtGamePublisher;
        private System.Windows.Forms.TextBox txtGameSystem;
        private System.Windows.Forms.Button btnSubmit;
    }
}