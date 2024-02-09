namespace EMart {
    partial class Form2 {
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
            this.labelLastLogIn = new System.Windows.Forms.Label();
            this.labelWorkerName = new System.Windows.Forms.Label();
            this.labelWorkerEmail = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.buttonPrintBill = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textProductId = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelGST = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCGST = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelWorkerId = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLastLogIn
            // 
            this.labelLastLogIn.AutoSize = true;
            this.labelLastLogIn.Location = new System.Drawing.Point(1089, 29);
            this.labelLastLogIn.Name = "labelLastLogIn";
            this.labelLastLogIn.Size = new System.Drawing.Size(127, 16);
            this.labelLastLogIn.TabIndex = 0;
            this.labelLastLogIn.Text = "Last Login : 2/7/2024";
            // 
            // labelWorkerName
            // 
            this.labelWorkerName.AutoSize = true;
            this.labelWorkerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkerName.Location = new System.Drawing.Point(12, 9);
            this.labelWorkerName.Name = "labelWorkerName";
            this.labelWorkerName.Size = new System.Drawing.Size(137, 31);
            this.labelWorkerName.TabIndex = 1;
            this.labelWorkerName.Text = "Hi, Mohan";
            // 
            // labelWorkerEmail
            // 
            this.labelWorkerEmail.AutoSize = true;
            this.labelWorkerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkerEmail.Location = new System.Drawing.Point(14, 43);
            this.labelWorkerEmail.Name = "labelWorkerEmail";
            this.labelWorkerEmail.Size = new System.Drawing.Size(76, 20);
            this.labelWorkerEmail.TabIndex = 2;
            this.labelWorkerEmail.Text = "mohan@";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1230, 541);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(949, 649);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.Location = new System.Drawing.Point(993, 641);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(65, 29);
            this.labelTotalPrice.TabIndex = 5;
            this.labelTotalPrice.Text = "3563";
            // 
            // buttonPrintBill
            // 
            this.buttonPrintBill.Location = new System.Drawing.Point(1146, 641);
            this.buttonPrintBill.Name = "buttonPrintBill";
            this.buttonPrintBill.Size = new System.Drawing.Size(96, 36);
            this.buttonPrintBill.TabIndex = 6;
            this.buttonPrintBill.Text = "Print Bill";
            this.buttonPrintBill.UseVisualStyleBackColor = true;
            this.buttonPrintBill.Click += new System.EventHandler(this.ButtonPrintBill_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(110, 640);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(131, 38);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "AddProduct";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // textProductId
            // 
            this.textProductId.Location = new System.Drawing.Point(18, 645);
            this.textProductId.Name = "textProductId";
            this.textProductId.Size = new System.Drawing.Size(85, 22);
            this.textProductId.TabIndex = 8;
            this.textProductId.Text = "ProductId";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(393, 641);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(131, 38);
            this.buttonClear.TabIndex = 9;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.Clear);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 651);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "GST 5%";
            // 
            // labelGST
            // 
            this.labelGST.AutoSize = true;
            this.labelGST.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGST.Location = new System.Drawing.Point(702, 643);
            this.labelGST.Name = "labelGST";
            this.labelGST.Size = new System.Drawing.Size(65, 29);
            this.labelGST.TabIndex = 11;
            this.labelGST.Text = "3563";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(782, 649);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "CGST 5%";
            // 
            // labelCGST
            // 
            this.labelCGST.AutoSize = true;
            this.labelCGST.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCGST.Location = new System.Drawing.Point(854, 641);
            this.labelCGST.Name = "labelCGST";
            this.labelCGST.Size = new System.Drawing.Size(65, 29);
            this.labelCGST.TabIndex = 13;
            this.labelCGST.Text = "3563";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(251, 641);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(131, 38);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "DeleteProduct";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // labelWorkerId
            // 
            this.labelWorkerId.AutoSize = true;
            this.labelWorkerId.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkerId.ForeColor = System.Drawing.Color.Red;
            this.labelWorkerId.Location = new System.Drawing.Point(441, 23);
            this.labelWorkerId.Name = "labelWorkerId";
            this.labelWorkerId.Size = new System.Drawing.Size(208, 30);
            this.labelWorkerId.TabIndex = 16;
            this.labelWorkerId.Text = "Worker Id : 123";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(936, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 38);
            this.button1.TabIndex = 17;
            this.button1.Text = "Show Receipts";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ShowReceipts);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(799, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 38);
            this.button2.TabIndex = 19;
            this.button2.Text = "Free Internet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(216, 29);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(166, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EMart.Properties.Resources.pexels_steve_johnson_1843717;
            this.ClientSize = new System.Drawing.Size(1254, 725);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelWorkerId);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelCGST);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelGST);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textProductId);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonPrintBill);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelWorkerEmail);
            this.Controls.Add(this.labelWorkerName);
            this.Controls.Add(this.labelLastLogIn);
            this.Name = "Form2";
            this.Text = "BillBox";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLastLogIn;
        private System.Windows.Forms.Label labelWorkerName;
        private System.Windows.Forms.Label labelWorkerEmail;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Button buttonPrintBill;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textProductId;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelGST;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCGST;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelWorkerId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}