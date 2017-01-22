namespace DnD
{
    partial class DnDMasterTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DnDMasterTool));
            this.initiative = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.DnDLogo = new System.Windows.Forms.PictureBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.TxtAddPlayer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DnDLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // initiative
            // 
            this.initiative.AutoSize = true;
            this.initiative.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initiative.ForeColor = System.Drawing.Color.White;
            this.initiative.Location = new System.Drawing.Point(1241, 75);
            this.initiative.Name = "initiative";
            this.initiative.Size = new System.Drawing.Size(0, 25);
            this.initiative.TabIndex = 136;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(1225, 22);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(178, 31);
            this.label45.TabIndex = 131;
            this.label45.Text = "INITIATIVE";
            // 
            // DnDLogo
            // 
            this.DnDLogo.Location = new System.Drawing.Point(1159, 173);
            this.DnDLogo.Name = "DnDLogo";
            this.DnDLogo.Size = new System.Drawing.Size(100, 50);
            this.DnDLogo.TabIndex = 137;
            this.DnDLogo.TabStop = false;
            this.DnDLogo.Visible = false;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.AutoSize = true;
            this.btnAddPlayer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddPlayer.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPlayer.ForeColor = System.Drawing.Color.White;
            this.btnAddPlayer.Location = new System.Drawing.Point(2, 19);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(107, 31);
            this.btnAddPlayer.TabIndex = 138;
            this.btnAddPlayer.Text = "Add Player";
            this.btnAddPlayer.UseVisualStyleBackColor = false;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // TxtAddPlayer
            // 
            this.TxtAddPlayer.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddPlayer.Location = new System.Drawing.Point(115, 21);
            this.TxtAddPlayer.Name = "TxtAddPlayer";
            this.TxtAddPlayer.Size = new System.Drawing.Size(127, 28);
            this.TxtAddPlayer.TabIndex = 139;
            // 
            // DnDMasterTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1434, 74);
            this.Controls.Add(this.TxtAddPlayer);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.DnDLogo);
            this.Controls.Add(this.initiative);
            this.Controls.Add(this.label45);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1450, 1000);
            this.Name = "DnDMasterTool";
            this.Text = "DnDMasterTool";
            ((System.ComponentModel.ISupportInitialize)(this.DnDLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label initiative;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.PictureBox DnDLogo;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.TextBox TxtAddPlayer;
    }
}