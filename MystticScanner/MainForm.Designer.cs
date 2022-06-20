namespace MystticScanner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SettingsBT = new System.Windows.Forms.Button();
            this.RemoveSelectedBT = new System.Windows.Forms.Button();
            this.SelectFileBT = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ReportLB = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Path = "P:\\myLaboratory\\Projects\\VisualStudioProjects\\MystticScanner\\MystticScanner\\bin\\D" +
    "ebug\\net5.0-windows";
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SettingsBT);
            this.panel1.Controls.Add(this.RemoveSelectedBT);
            this.panel1.Controls.Add(this.SelectFileBT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(165, 466);
            this.panel1.TabIndex = 0;
            // 
            // SettingsBT
            // 
            this.SettingsBT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SettingsBT.Location = new System.Drawing.Point(5, 438);
            this.SettingsBT.Name = "SettingsBT";
            this.SettingsBT.Size = new System.Drawing.Size(155, 23);
            this.SettingsBT.TabIndex = 2;
            this.SettingsBT.Text = "Settings";
            this.SettingsBT.UseVisualStyleBackColor = true;
            this.SettingsBT.Click += new System.EventHandler(this.SettingsBT_Click);
            // 
            // RemoveSelectedBT
            // 
            this.RemoveSelectedBT.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemoveSelectedBT.Location = new System.Drawing.Point(5, 28);
            this.RemoveSelectedBT.Name = "RemoveSelectedBT";
            this.RemoveSelectedBT.Size = new System.Drawing.Size(155, 23);
            this.RemoveSelectedBT.TabIndex = 1;
            this.RemoveSelectedBT.Text = "Remove selected";
            this.RemoveSelectedBT.UseVisualStyleBackColor = true;
            this.RemoveSelectedBT.Click += new System.EventHandler(this.RemoveSelectedBT_Click);
            // 
            // SelectFileBT
            // 
            this.SelectFileBT.Dock = System.Windows.Forms.DockStyle.Top;
            this.SelectFileBT.Location = new System.Drawing.Point(5, 5);
            this.SelectFileBT.Name = "SelectFileBT";
            this.SelectFileBT.Size = new System.Drawing.Size(155, 23);
            this.SelectFileBT.TabIndex = 0;
            this.SelectFileBT.Text = "Select file";
            this.SelectFileBT.UseVisualStyleBackColor = true;
            this.SelectFileBT.Click += new System.EventHandler(this.SelectFileBT_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ReportLB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(165, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 466);
            this.panel2.TabIndex = 1;
            // 
            // ReportLB
            // 
            this.ReportLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportLB.FormattingEnabled = true;
            this.ReportLB.ItemHeight = 15;
            this.ReportLB.Location = new System.Drawing.Point(0, 0);
            this.ReportLB.Name = "ReportLB";
            this.ReportLB.Size = new System.Drawing.Size(740, 466);
            this.ReportLB.TabIndex = 0;
            this.ReportLB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ReportLB_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 466);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainForm";
            this.Text = "MystticScanner";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox ReportLB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SettingsBT;
        private System.Windows.Forms.Button RemoveSelectedBT;
        private System.Windows.Forms.Button SelectFileBT;
    }
}
