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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.lstPrimary = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSecondary = new System.Windows.Forms.ListBox();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 20);
            this.textBox1.TabIndex = 0;
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "Name",
            "School",
            "Division"});
            this.cboFilter.Location = new System.Drawing.Point(422, 12);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(145, 21);
            this.cboFilter.TabIndex = 1;
            this.cboFilter.TabStop = false;
            // 
            // lstPrimary
            // 
            this.lstPrimary.FormattingEnabled = true;
            this.lstPrimary.Location = new System.Drawing.Point(74, 58);
            this.lstPrimary.Name = "lstPrimary";
            this.lstPrimary.Size = new System.Drawing.Size(234, 355);
            this.lstPrimary.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 54);
            this.button1.TabIndex = 4;
            this.button1.Text = "Open DataSheet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(341, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter By:";
            // 
            // lstSecondary
            // 
            this.lstSecondary.FormattingEnabled = true;
            this.lstSecondary.Location = new System.Drawing.Point(333, 58);
            this.lstSecondary.Name = "lstSecondary";
            this.lstSecondary.Size = new System.Drawing.Size(234, 355);
            this.lstSecondary.TabIndex = 6;
            this.lstSecondary.Visible = false;
            // 
            // ofdOpen
            // 
            this.ofdOpen.Title = "Open Tournament Datasheet:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 534);
            this.Controls.Add(this.lstSecondary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPrimary);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "NASP Tournament Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.ListBox lstPrimary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstSecondary;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
    }
}

