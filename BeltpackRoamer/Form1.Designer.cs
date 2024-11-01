namespace BeltpackRoamer
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.projectFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.beltpackRoleDropdown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.configurationDropDown = new System.Windows.Forms.ComboBox();
            this.transceiverList = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.roamingLog = new System.Windows.Forms.TextBox();
            this.btnAutoRoam = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.hxn";
            this.openFileDialog1.Filter = "HXN Project|*.hxn";
            // 
            // projectFilename
            // 
            this.projectFilename.Location = new System.Drawing.Point(111, 7);
            this.projectFilename.Name = "projectFilename";
            this.projectFilename.Size = new System.Drawing.Size(306, 22);
            this.projectFilename.TabIndex = 0;
            this.projectFilename.Text = "Select an HXN file...";
            this.projectFilename.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "EHX HXN File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Beltpack Role:";
            // 
            // beltpackRoleDropdown
            // 
            this.beltpackRoleDropdown.FormattingEnabled = true;
            this.beltpackRoleDropdown.Location = new System.Drawing.Point(111, 93);
            this.beltpackRoleDropdown.Name = "beltpackRoleDropdown";
            this.beltpackRoleDropdown.Size = new System.Drawing.Size(306, 24);
            this.beltpackRoleDropdown.TabIndex = 4;
            this.beltpackRoleDropdown.SelectedIndexChanged += new System.EventHandler(this.beltpackRoleDropdown_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Configuration:";
            // 
            // configurationDropDown
            // 
            this.configurationDropDown.FormattingEnabled = true;
            this.configurationDropDown.Location = new System.Drawing.Point(111, 46);
            this.configurationDropDown.Name = "configurationDropDown";
            this.configurationDropDown.Size = new System.Drawing.Size(306, 24);
            this.configurationDropDown.TabIndex = 6;
            this.configurationDropDown.SelectedIndexChanged += new System.EventHandler(this.configurationDropDown_SelectedIndexChanged);
            // 
            // transceiverList
            // 
            this.transceiverList.FormattingEnabled = true;
            this.transceiverList.Location = new System.Drawing.Point(12, 162);
            this.transceiverList.Name = "transceiverList";
            this.transceiverList.Size = new System.Drawing.Size(405, 259);
            this.transceiverList.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Transceivers:";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(316, 428);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 29);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // roamingLog
            // 
            this.roamingLog.Location = new System.Drawing.Point(12, 461);
            this.roamingLog.Multiline = true;
            this.roamingLog.Name = "roamingLog";
            this.roamingLog.Size = new System.Drawing.Size(405, 137);
            this.roamingLog.TabIndex = 10;
            // 
            // btnAutoRoam
            // 
            this.btnAutoRoam.Location = new System.Drawing.Point(12, 428);
            this.btnAutoRoam.Name = "btnAutoRoam";
            this.btnAutoRoam.Size = new System.Drawing.Size(132, 29);
            this.btnAutoRoam.TabIndex = 11;
            this.btnAutoRoam.Text = "Auto Roam OFF";
            this.btnAutoRoam.UseVisualStyleBackColor = true;
            this.btnAutoRoam.Click += new System.EventHandler(this.btnAutoRoam_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(209, 428);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 29);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(332, 136);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 20);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 603);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAutoRoam);
            this.Controls.Add(this.roamingLog);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.transceiverList);
            this.Controls.Add(this.configurationDropDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.beltpackRoleDropdown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectFilename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Beltpack Roaming Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox projectFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox beltpackRoleDropdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox configurationDropDown;
        private System.Windows.Forms.CheckedListBox transceiverList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox roamingLog;
        private System.Windows.Forms.Button btnAutoRoam;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

