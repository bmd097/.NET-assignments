using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMart {
    public partial class Form3 : Form {

        private ReceiptDB receiptDB = new ReceiptDB();  

        public Form3() {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e) {
            dataGridViewReceipts.Rows.Clear();

            dataGridViewReceipts.ColumnCount = 4;

            dataGridViewReceipts.Columns[0].Name = "Product ID";
            dataGridViewReceipts.Columns[1].Name = "Details";
            dataGridViewReceipts.Columns[2].Name = "Price";
            dataGridViewReceipts.Columns[3].Name = "CreatedAt";

            dataGridViewReceipts.AllowUserToAddRows = false;
            dataGridViewReceipts.CellDoubleClick += (i, p) => {
                try {
                    var rows = dataGridViewReceipts.Rows[p.RowIndex];
                    MessageBox.Show(rows.Cells[p.ColumnIndex].Value.ToString(), "Info!");
                } catch (Exception) { }
            };

            receiptDB.ShowAllReceipts();
            foreach(var receipt in receiptDB.ShowAllReceipts()) {
                dataGridViewReceipts.Rows.Add(receipt);
            }
        }
    }
}
