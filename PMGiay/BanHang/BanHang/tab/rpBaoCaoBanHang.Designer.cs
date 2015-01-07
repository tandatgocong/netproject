namespace BanHang.tab
{
    partial class rpBaoCaoBanHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.theodoi_denngay = new System.Windows.Forms.DateTimePicker();
            this.theodoi_tungay = new System.Windows.Forms.DateTimePicker();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelX15);
            this.splitContainer1.Panel1.Controls.Add(this.theodoi_denngay);
            this.splitContainer1.Panel1.Controls.Add(this.theodoi_tungay);
            this.splitContainer1.Panel1.Controls.Add(this.labelX14);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1035, 583);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 1;
            // 
            // labelX15
            // 
            this.labelX15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelX15.Location = new System.Drawing.Point(332, 13);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(38, 23);
            this.labelX15.TabIndex = 705;
            this.labelX15.Text = "Đến";
            // 
            // theodoi_denngay
            // 
            this.theodoi_denngay.CustomFormat = "dd/MM/yyyy";
            this.theodoi_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.theodoi_denngay.Location = new System.Drawing.Point(378, 12);
            this.theodoi_denngay.Name = "theodoi_denngay";
            this.theodoi_denngay.Size = new System.Drawing.Size(98, 26);
            this.theodoi_denngay.TabIndex = 703;
            this.theodoi_denngay.ValueChanged += new System.EventHandler(this.theodoi_denngay_ValueChanged);
            // 
            // theodoi_tungay
            // 
            this.theodoi_tungay.CustomFormat = "dd/MM/yyyy";
            this.theodoi_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.theodoi_tungay.Location = new System.Drawing.Point(224, 12);
            this.theodoi_tungay.Name = "theodoi_tungay";
            this.theodoi_tungay.Size = new System.Drawing.Size(100, 26);
            this.theodoi_tungay.TabIndex = 702;
            this.theodoi_tungay.ValueChanged += new System.EventHandler(this.theodoi_tungay_ValueChanged);
            // 
            // labelX14
            // 
            this.labelX14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelX14.Location = new System.Drawing.Point(27, 13);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(241, 23);
            this.labelX14.TabIndex = 704;
            this.labelX14.Text = "Hóa Đơn Bán Hàng Từ Ngày";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BanHang.tab.rpBaoCaoBanHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1035, 530);
            this.reportViewer1.TabIndex = 0;
            // 
            // rpBaoCaoBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "rpBaoCaoBanHang";
            this.Size = new System.Drawing.Size(1035, 583);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.LabelX labelX15;
        private System.Windows.Forms.DateTimePicker theodoi_denngay;
        private System.Windows.Forms.DateTimePicker theodoi_tungay;
        private DevComponents.DotNetBar.LabelX labelX14;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;





    }
}
