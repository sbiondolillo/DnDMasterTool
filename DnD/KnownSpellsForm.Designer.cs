namespace DnD
{
    partial class KnownSpellsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KnownSpellsForm));
            this.lblSpellInfo = new System.Windows.Forms.Label();
            this.txtSpellSearch = new System.Windows.Forms.TextBox();
            this.btnAddSpell = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstBoxSearch = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblSpellInfo
            // 
            this.lblSpellInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblSpellInfo.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.lblSpellInfo.ForeColor = System.Drawing.Color.White;
            this.lblSpellInfo.Image = ((System.Drawing.Image)(resources.GetObject("lblSpellInfo.Image")));
            this.lblSpellInfo.Location = new System.Drawing.Point(460, 9);
            this.lblSpellInfo.Name = "lblSpellInfo";
            this.lblSpellInfo.Size = new System.Drawing.Size(994, 695);
            this.lblSpellInfo.TabIndex = 0;
            this.lblSpellInfo.Text = "Click on a spell to see info on it!";
            // 
            // txtSpellSearch
            // 
            this.txtSpellSearch.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpellSearch.Location = new System.Drawing.Point(10, 665);
            this.txtSpellSearch.Name = "txtSpellSearch";
            this.txtSpellSearch.Size = new System.Drawing.Size(172, 28);
            this.txtSpellSearch.TabIndex = 1;
            this.txtSpellSearch.TextChanged += new System.EventHandler(this.txtSpellSearch_TextChanged);
            // 
            // btnAddSpell
            // 
            this.btnAddSpell.AutoSize = true;
            this.btnAddSpell.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSpell.Location = new System.Drawing.Point(187, 663);
            this.btnAddSpell.Name = "btnAddSpell";
            this.btnAddSpell.Size = new System.Drawing.Size(95, 31);
            this.btnAddSpell.TabIndex = 3;
            this.btnAddSpell.Text = "Add Spell";
            this.btnAddSpell.UseVisualStyleBackColor = true;
            this.btnAddSpell.Click += new System.EventHandler(this.btnAddSpell_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 641);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seach Spells";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Known Spells";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(245, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search Results";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstBoxSearch
            // 
            this.lstBoxSearch.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lstBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoxSearch.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxSearch.ForeColor = System.Drawing.Color.Transparent;
            this.lstBoxSearch.FormattingEnabled = true;
            this.lstBoxSearch.ItemHeight = 21;
            this.lstBoxSearch.Location = new System.Drawing.Point(250, 48);
            this.lstBoxSearch.Name = "lstBoxSearch";
            this.lstBoxSearch.Size = new System.Drawing.Size(204, 588);
            this.lstBoxSearch.TabIndex = 6;
            this.lstBoxSearch.Click += new System.EventHandler(this.lstBoxSearch_Click);
            // 
            // KnownSpellsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1466, 713);
            this.Controls.Add(this.lstBoxSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddSpell);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSpellSearch);
            this.Controls.Add(this.lblSpellInfo);
            this.DoubleBuffered = true;
            this.Name = "KnownSpellsForm";
            this.Text = "KnownSpellsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpellInfo;
        private System.Windows.Forms.TextBox txtSpellSearch;
        private System.Windows.Forms.Button btnAddSpell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBoxSearch;
    }
}