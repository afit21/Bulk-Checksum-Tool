
namespace WinToolKit
{
    partial class Results
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filePath,
            this.CheckSum});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(678, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // filePath
            // 
            this.filePath.HeaderText = "File Path";
            this.filePath.Name = "filePath";
            this.filePath.Width = 350;
            // 
            // CheckSum
            // 
            this.CheckSum.HeaderText = "CheckSum";
            this.CheckSum.Name = "CheckSum";
            this.CheckSum.Width = 350;
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImage = global::AFCT.Properties.Resources.cpuart;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.Coral;
            this.btnExport.Location = new System.Drawing.Point(703, 363);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 75);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export as CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Results";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Results_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckSum;
        private System.Windows.Forms.Button btnExport;
    }
}