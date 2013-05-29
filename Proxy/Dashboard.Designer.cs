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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.gb_serverList = new System.Windows.Forms.GroupBox();
            this.lv_serverList = new System.Windows.Forms.ListView();
            this.gb_serverDetail = new System.Windows.Forms.GroupBox();
            this.chartCpu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMem = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.b_serverStatus = new System.Windows.Forms.Button();
            this.ta_serverInfo = new System.Windows.Forms.TextBox();
            this.gb_serverList.SuspendLayout();
            this.gb_serverDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMem)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_serverList
            // 
            this.gb_serverList.Controls.Add(this.lv_serverList);
            this.gb_serverList.Location = new System.Drawing.Point(12, 12);
            this.gb_serverList.Name = "gb_serverList";
            this.gb_serverList.Size = new System.Drawing.Size(234, 314);
            this.gb_serverList.TabIndex = 0;
            this.gb_serverList.TabStop = false;
            this.gb_serverList.Text = "Server";
            // 
            // lv_serverList
            // 
            this.lv_serverList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lv_serverList.Location = new System.Drawing.Point(6, 19);
            this.lv_serverList.MultiSelect = false;
            this.lv_serverList.Name = "lv_serverList";
            this.lv_serverList.Size = new System.Drawing.Size(222, 289);
            this.lv_serverList.TabIndex = 2;
            this.lv_serverList.UseCompatibleStateImageBehavior = false;
            this.lv_serverList.View = System.Windows.Forms.View.List;
            this.lv_serverList.SelectedIndexChanged += new System.EventHandler(this.lv_serverList_SelectedIndexChanged);
            // 
            // gb_serverDetail
            // 
            this.gb_serverDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_serverDetail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_serverDetail.Controls.Add(this.chartCpu);
            this.gb_serverDetail.Controls.Add(this.chartMem);
            this.gb_serverDetail.Controls.Add(this.b_serverStatus);
            this.gb_serverDetail.Controls.Add(this.ta_serverInfo);
            this.gb_serverDetail.Location = new System.Drawing.Point(252, 12);
            this.gb_serverDetail.Name = "gb_serverDetail";
            this.gb_serverDetail.Size = new System.Drawing.Size(540, 320);
            this.gb_serverDetail.TabIndex = 1;
            this.gb_serverDetail.TabStop = false;
            this.gb_serverDetail.Text = "Server:";
            this.gb_serverDetail.Visible = false;
            // 
            // chartCpu
            // 
            this.chartCpu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisX2.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisY.MaximumAutoSize = 85F;
            chartArea1.AxisY2.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisY2.MaximumAutoSize = 85F;
            chartArea1.Name = "cpu";
            this.chartCpu.ChartAreas.Add(chartArea1);
            this.chartCpu.Location = new System.Drawing.Point(274, 50);
            this.chartCpu.Name = "chartCpu";
            this.chartCpu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chartCpu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "cpu";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Crimson;
            series1.Name = "cpu";
            this.chartCpu.Series.Add(series1);
            this.chartCpu.Size = new System.Drawing.Size(260, 128);
            this.chartCpu.TabIndex = 4;
            this.chartCpu.Text = "chart_cpu";
            title1.Name = "cpu";
            title1.Text = "CPU Usage (%)";
            this.chartCpu.Titles.Add(title1);
            // 
            // chartMem
            // 
            this.chartMem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea2.AxisX2.LabelAutoFitMinFontSize = 5;
            chartArea2.AxisY.LabelAutoFitMinFontSize = 5;
            chartArea2.AxisY.MaximumAutoSize = 85F;
            chartArea2.AxisY2.LabelAutoFitMinFontSize = 5;
            chartArea2.AxisY2.MaximumAutoSize = 85F;
            chartArea2.Name = "Memory";
            this.chartMem.ChartAreas.Add(chartArea2);
            this.chartMem.Location = new System.Drawing.Point(274, 186);
            this.chartMem.Name = "chartMem";
            this.chartMem.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chartMem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series2.ChartArea = "Memory";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.RoyalBlue;
            series2.Name = "mem";
            this.chartMem.Series.Add(series2);
            this.chartMem.Size = new System.Drawing.Size(260, 128);
            this.chartMem.TabIndex = 3;
            this.chartMem.Text = "chart_mem";
            title2.Name = "mem";
            title2.Text = "Free Memory (MB)";
            this.chartMem.Titles.Add(title2);
            // 
            // b_serverStatus
            // 
            this.b_serverStatus.Location = new System.Drawing.Point(459, 19);
            this.b_serverStatus.Name = "b_serverStatus";
            this.b_serverStatus.Size = new System.Drawing.Size(75, 23);
            this.b_serverStatus.TabIndex = 1;
            this.b_serverStatus.UseVisualStyleBackColor = true;
            this.b_serverStatus.Click += new System.EventHandler(this.b_serverStatus_Click);
            // 
            // ta_serverInfo
            // 
            this.ta_serverInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ta_serverInfo.Location = new System.Drawing.Point(6, 19);
            this.ta_serverInfo.Multiline = true;
            this.ta_serverInfo.Name = "ta_serverInfo";
            this.ta_serverInfo.Size = new System.Drawing.Size(262, 295);
            this.ta_serverInfo.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 344);
            this.Controls.Add(this.gb_serverDetail);
            this.Controls.Add(this.gb_serverList);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.gb_serverList.ResumeLayout(false);
            this.gb_serverDetail.ResumeLayout(false);
            this.gb_serverDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_serverList;
        private System.Windows.Forms.GroupBox gb_serverDetail;
        private System.Windows.Forms.TextBox ta_serverInfo;
        private System.Windows.Forms.Button b_serverStatus;
        private System.Windows.Forms.ListView lv_serverList;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCpu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMem;
    }
}