namespace Proxy
{
    partial class Dashboard
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
            this.gb_serverList = new System.Windows.Forms.GroupBox();
            this.lb_serverList = new System.Windows.Forms.ListBox();
            this.gb_serverDetail = new System.Windows.Forms.GroupBox();
            this.ta_serverInfo = new System.Windows.Forms.TextBox();
            this.gb_serverList.SuspendLayout();
            this.gb_serverDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_serverList
            // 
            this.gb_serverList.Controls.Add(this.lb_serverList);
            this.gb_serverList.Location = new System.Drawing.Point(12, 12);
            this.gb_serverList.Name = "gb_serverList";
            this.gb_serverList.Size = new System.Drawing.Size(200, 237);
            this.gb_serverList.TabIndex = 0;
            this.gb_serverList.TabStop = false;
            this.gb_serverList.Text = "Server";
            // 
            // lb_serverList
            // 
            this.lb_serverList.FormattingEnabled = true;
            this.lb_serverList.Location = new System.Drawing.Point(6, 19);
            this.lb_serverList.Name = "lb_serverList";
            this.lb_serverList.Size = new System.Drawing.Size(188, 212);
            this.lb_serverList.TabIndex = 0;
            this.lb_serverList.SelectedIndexChanged += new System.EventHandler(this.lb_serverList_SelectedIndexChanged);
            // 
            // gb_serverDetail
            // 
            this.gb_serverDetail.Controls.Add(this.ta_serverInfo);
            this.gb_serverDetail.Location = new System.Drawing.Point(227, 12);
            this.gb_serverDetail.Name = "gb_serverDetail";
            this.gb_serverDetail.Size = new System.Drawing.Size(433, 237);
            this.gb_serverDetail.TabIndex = 1;
            this.gb_serverDetail.TabStop = false;
            this.gb_serverDetail.Text = "Server:";
            this.gb_serverDetail.Visible = false;
            // 
            // ta_serverInfo
            // 
            this.ta_serverInfo.Location = new System.Drawing.Point(6, 19);
            this.ta_serverInfo.Multiline = true;
            this.ta_serverInfo.Name = "ta_serverInfo";
            this.ta_serverInfo.Size = new System.Drawing.Size(421, 212);
            this.ta_serverInfo.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 261);
            this.Controls.Add(this.gb_serverDetail);
            this.Controls.Add(this.gb_serverList);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.gb_serverList.ResumeLayout(false);
            this.gb_serverDetail.ResumeLayout(false);
            this.gb_serverDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_serverList;
        private System.Windows.Forms.ListBox lb_serverList;
        private System.Windows.Forms.GroupBox gb_serverDetail;
        private System.Windows.Forms.TextBox ta_serverInfo;
    }
}