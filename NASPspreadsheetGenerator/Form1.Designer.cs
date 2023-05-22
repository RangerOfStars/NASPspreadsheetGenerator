namespace NASPspreadsheetGenerator
{
    partial class Form1
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
            this.txtPrimary = new System.Windows.Forms.TextBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.lstPrimary = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSecondary = new System.Windows.Forms.ListBox();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblArcher = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPrimary
            // 
            this.txtPrimary.Location = new System.Drawing.Point(99, 21);
            this.txtPrimary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrimary.Name = "txtPrimary";
            this.txtPrimary.Size = new System.Drawing.Size(311, 22);
            this.txtPrimary.TabIndex = 0;
            this.txtPrimary.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "Name",
            "School",
            "Division"});
            this.cboFilter.Location = new System.Drawing.Point(563, 15);
            this.cboFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(192, 24);
            this.cboFilter.TabIndex = 1;
            this.cboFilter.TabStop = false;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lstPrimary
            // 
            this.lstPrimary.FormattingEnabled = true;
            this.lstPrimary.ItemHeight = 16;
            this.lstPrimary.Location = new System.Drawing.Point(99, 71);
            this.lstPrimary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstPrimary.Name = "lstPrimary";
            this.lstPrimary.Size = new System.Drawing.Size(311, 436);
            this.lstPrimary.Sorted = true;
            this.lstPrimary.TabIndex = 2;
            this.lstPrimary.Click += new System.EventHandler(this.lstPrimary_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 576);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 66);
            this.button1.TabIndex = 4;
            this.button1.Text = "Open Archer DataSheet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(455, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter By:";
            // 
            // lstSecondary
            // 
            this.lstSecondary.FormattingEnabled = true;
            this.lstSecondary.ItemHeight = 16;
            this.lstSecondary.Location = new System.Drawing.Point(444, 71);
            this.lstSecondary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstSecondary.Name = "lstSecondary";
            this.lstSecondary.Size = new System.Drawing.Size(311, 436);
            this.lstSecondary.Sorted = true;
            this.lstSecondary.TabIndex = 6;
            this.lstSecondary.Visible = false;
            this.lstSecondary.Click += new System.EventHandler(this.lstSecondary_Click);
            // 
            // ofdOpen
            // 
            this.ofdOpen.Title = "Open Tournament Datasheet:";
            // 
            // lblArcher
            // 
            this.lblArcher.AutoSize = true;
            this.lblArcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArcher.Location = new System.Drawing.Point(823, 15);
            this.lblArcher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArcher.Name = "lblArcher";
            this.lblArcher.Size = new System.Drawing.Size(0, 24);
            this.lblArcher.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 657);
            this.Controls.Add(this.lblArcher);
            this.Controls.Add(this.lstSecondary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPrimary);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.txtPrimary);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "NASP Tournament Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrimary;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.ListBox lstPrimary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstSecondary;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.Label lblArcher;
    }
}

