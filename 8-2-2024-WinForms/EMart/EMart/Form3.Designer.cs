namespace EMart {
    partial class Form3 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridViewReceipts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReceipts
            // 
            this.dataGridViewReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReceipts.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewReceipts.Name = "dataGridViewReceipts";
            this.dataGridViewReceipts.RowHeadersWidth = 51;
            this.dataGridViewReceipts.RowTemplate.Height = 24;
            this.dataGridViewReceipts.Size = new System.Drawing.Size(1645, 553);
            this.dataGridViewReceipts.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 577);
            this.Controls.Add(this.dataGridViewReceipts);
            this.Name = "Form3";
            this.Text = "Receipts";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReceipts;
    }
}