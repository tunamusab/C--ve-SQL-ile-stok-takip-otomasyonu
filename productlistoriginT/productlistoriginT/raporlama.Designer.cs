
namespace productlistoriginT
{
    partial class raporlama
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(raporlama));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.stoktakipDataSet = new productlistoriginT.stoktakipDataSet();
            this.ürün_bilgisiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ürün_bilgisiTableAdapter = new productlistoriginT.stoktakipDataSetTableAdapters.ürün_bilgisiTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stoktakipDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ürün_bilgisiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ürün_bilgisiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "productlistoriginT.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(27, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1079, 554);
            this.reportViewer1.TabIndex = 0;
            // 
            // stoktakipDataSet1
            // 
            this.stoktakipDataSet.DataSetName = "stoktakipDataSet1";
            this.stoktakipDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ürün_bilgisiBindingSource
            // 
            this.ürün_bilgisiBindingSource.DataMember = "ürün_bilgisi";
            this.ürün_bilgisiBindingSource.DataSource = this.stoktakipDataSet;
            // 
            // ürün_bilgisiTableAdapter
            // 
            this.ürün_bilgisiTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1094, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 27);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // raporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1136, 632);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "raporlama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "raporlama";
            this.Load += new System.EventHandler(this.raporlama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stoktakipDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ürün_bilgisiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ürün_bilgisiBindingSource;
        private stoktakipDataSet stoktakipDataSet;
        private stoktakipDataSetTableAdapters.ürün_bilgisiTableAdapter ürün_bilgisiTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}