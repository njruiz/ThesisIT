namespace CertificateTextEntityClassificationSystem
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_presenter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_date = new System.Windows.Forms.TextBox();
            this.txt_recipient = new System.Windows.Forms.TextBox();
            this.txt_award = new System.Windows.Forms.TextBox();
            this.txt_type = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_ShowDB = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_terminate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rich_status = new System.Windows.Forms.RichTextBox();
            this.txt_confidence = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_prep = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(609, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "-OUTPUT-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(533, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Presenter:";
            // 
            // txt_presenter
            // 
            this.txt_presenter.Location = new System.Drawing.Point(536, 231);
            this.txt_presenter.Name = "txt_presenter";
            this.txt_presenter.Size = new System.Drawing.Size(224, 20);
            this.txt_presenter.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(533, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Recipient:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Award:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Certificate Type:";
            // 
            // txt_date
            // 
            this.txt_date.Location = new System.Drawing.Point(536, 280);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(224, 20);
            this.txt_date.TabIndex = 23;
            // 
            // txt_recipient
            // 
            this.txt_recipient.Location = new System.Drawing.Point(536, 179);
            this.txt_recipient.Name = "txt_recipient";
            this.txt_recipient.Size = new System.Drawing.Size(224, 20);
            this.txt_recipient.TabIndex = 22;
            // 
            // txt_award
            // 
            this.txt_award.Location = new System.Drawing.Point(536, 127);
            this.txt_award.Name = "txt_award";
            this.txt_award.Size = new System.Drawing.Size(224, 20);
            this.txt_award.TabIndex = 21;
            // 
            // txt_type
            // 
            this.txt_type.Location = new System.Drawing.Point(536, 79);
            this.txt_type.Name = "txt_type";
            this.txt_type.Size = new System.Drawing.Size(224, 20);
            this.txt_type.TabIndex = 20;
            // 
            // btn_start
            // 
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(653, 312);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(107, 37);
            this.btn_start.TabIndex = 19;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_ShowDB
            // 
            this.btn_ShowDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ShowDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowDB.Location = new System.Drawing.Point(534, 443);
            this.btn_ShowDB.Name = "btn_ShowDB";
            this.btn_ShowDB.Size = new System.Drawing.Size(82, 25);
            this.btn_ShowDB.TabIndex = 34;
            this.btn_ShowDB.Text = "Show DB";
            this.btn_ShowDB.UseVisualStyleBackColor = true;
            this.btn_ShowDB.Click += new System.EventHandler(this.btn_ShowDB_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pause.Location = new System.Drawing.Point(534, 408);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(82, 25);
            this.btn_pause.TabIndex = 33;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // btn_terminate
            // 
            this.btn_terminate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_terminate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_terminate.Location = new System.Drawing.Point(534, 479);
            this.btn_terminate.Name = "btn_terminate";
            this.btn_terminate.Size = new System.Drawing.Size(82, 25);
            this.btn_terminate.TabIndex = 32;
            this.btn_terminate.Text = "Terminate";
            this.btn_terminate.UseVisualStyleBackColor = true;
            this.btn_terminate.Click += new System.EventHandler(this.btn_terminate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Status:";
            // 
            // rich_status
            // 
            this.rich_status.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rich_status.Location = new System.Drawing.Point(12, 408);
            this.rich_status.Name = "rich_status";
            this.rich_status.ReadOnly = true;
            this.rich_status.Size = new System.Drawing.Size(500, 153);
            this.rich_status.TabIndex = 30;
            this.rich_status.Text = "";
            // 
            // txt_confidence
            // 
            this.txt_confidence.Location = new System.Drawing.Point(534, 525);
            this.txt_confidence.Name = "txt_confidence";
            this.txt_confidence.ReadOnly = true;
            this.txt_confidence.Size = new System.Drawing.Size(82, 20);
            this.txt_confidence.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(533, 548);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Confidence (%)";
            // 
            // btn_prep
            // 
            this.btn_prep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_prep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prep.Location = new System.Drawing.Point(534, 312);
            this.btn_prep.Name = "btn_prep";
            this.btn_prep.Size = new System.Drawing.Size(107, 37);
            this.btn_prep.TabIndex = 37;
            this.btn_prep.Text = "PREP";
            this.btn_prep.UseVisualStyleBackColor = true;
            this.btn_prep.Click += new System.EventHandler(this.btn_prep_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 573);
            this.Controls.Add(this.btn_prep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_confidence);
            this.Controls.Add(this.btn_ShowDB);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_terminate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rich_status);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_presenter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.txt_recipient);
            this.Controls.Add(this.txt_award);
            this.Controls.Add(this.txt_type);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificate Text Entity Miner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_presenter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_date;
        private System.Windows.Forms.TextBox txt_recipient;
        private System.Windows.Forms.TextBox txt_award;
        private System.Windows.Forms.TextBox txt_type;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_ShowDB;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_terminate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rich_status;
        private System.Windows.Forms.TextBox txt_confidence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_prep;
    }
}

