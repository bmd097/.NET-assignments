using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EMart {
    public partial class Form2 : Form {
        private Person person;
        private ProductsDB productsDB;
        private Dictionary<int, Product> currentCart;
        private ReceiptDB receiptDB;
        Dictionary<int, int> newQuantityViewDict;
        private String currentDetails;
        private int currentTotal;

        public Form2() {
            InitializeComponent();
        }
        public Form2(Person person) : this(){
            this.person = person;
            this.productsDB = new ProductsDB();
            this.currentCart = new Dictionary<int, Product>();
            this.receiptDB = new ReceiptDB();
            this.newQuantityViewDict = new Dictionary<int, int>();
        }

        private void Form2_Load(object sender, EventArgs e) {

            labelWorkerId.Text = "WORKER ID "+person.id.ToString();

            labelWorkerName.Text = "Hi, " + person.name;
            labelWorkerEmail.Text = person.email;
            labelLastLogIn.Text = "Last LogIn : "+person.lastLogIn.ToShortDateString();

            Controls.Add(dataGridView1);
            dataGridView1.ColumnCount = 5;

            dataGridView1.Columns[0].Name = "Product ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[2].Name = "Description";
            dataGridView1.Columns[3].Name = "Quantity";
            dataGridView1.Columns[4].Name = "Price";

            dataGridView1.CellDoubleClick += (i, p) => {
                try {
                    var rows = dataGridView1.Rows[p.RowIndex];
                    MessageBox.Show(rows.Cells[p.ColumnIndex].Value.ToString(), "Info!");
                } catch (Exception) { }
            };

            dataGridView1.AllowUserToAddRows = false;

            RenderItems();

            this.Menu = new MainMenu();
            MenuItem fileMenu = new MenuItem("Help");
            this.Menu.MenuItems.Add(fileMenu);
            fileMenu.MenuItems.Add("Creator", (o,p) => {
                MessageBox.Show("This product is created by Biswamohan Dwari.\n2024 | EPAM","Release");
            });

            progressBar1.Visible = false;

        }

        private void RenderItems() {
            dataGridView1.Rows.Clear();
            int totalPrice = 0;
            currentDetails = "";
            foreach (var product in currentCart.Values) {
                string[] value = { product.id.ToString(), product.name,product.description, product.qty.ToString(), product.price.ToString() };
                dataGridView1.Rows.Add(value);
                currentDetails += string.Join("-", value)+"\n";
                totalPrice += product.price * product.qty;
            }
            var gst = (5.0 / 100 * totalPrice);
            var cgst = (5.0 / 100 * totalPrice);
            labelGST.Text = gst.ToString();
            labelCGST.Text = cgst.ToString();
            labelTotalPrice.Text = (totalPrice + gst + cgst).ToString() + "$";
            currentTotal = (int)(totalPrice + gst + cgst);
            currentDetails += $"GST :: ${gst} CGST :: ${cgst} TOTAL :: ${labelTotalPrice.Text}";
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            try {
                string text = textProductId.Text;
                textProductId.Text = "";
                int id = int.Parse(text);
                var product = productsDB[id];
                if(product == null) {
                    MessageBox.Show($"Not available", "Invalid Product!", MessageBoxButtons.OK);
                    return;
                }
                if (product.qty > 0) {
                    product.qty = product.qty - 1;
                    newQuantityViewDict[product.id] = product.qty;
                    if (currentCart.ContainsKey(id)) {
                        currentCart[id].qty++;
                    } else {
                        Product cartProduct = new Product();
                        cartProduct.id = product.id; cartProduct.name = product.name;
                        cartProduct.price = product.price;
                        cartProduct.description = product.description;
                        cartProduct.qty = 1;
                        currentCart[id] = cartProduct;
                    }
                    RenderItems();
                } else {
                    MessageBox.Show($"{product.name} :: stock not available", "Stock Unavailable!", MessageBoxButtons.OK);
                }
                
            }catch(Exception e1) {

            }
        }

        private void ButtonPrintBill_Click(object sender, EventArgs e) {
            string value = MessageBox.Show($"Amount : {labelTotalPrice.Text}", "Print Bill", MessageBoxButtons.OKCancel).ToString();
            productsDB.SetQuantitiesInDB(newQuantityViewDict);
            if(currentTotal!=0) receiptDB.SaveToDB(currentDetails, currentTotal);
            if (value == "OK") {
                MessageBox.Show("Check the printer!", "Printing Bill", MessageBoxButtons.OK);
                dataGridView1.Rows.Clear();
                currentCart.Clear();
                labelTotalPrice.Text = "0$";
                labelGST.Text = "0$";
                newQuantityViewDict.Clear();
                labelCGST.Text = "0$";
            } 
        }

        private void Clear(object sender, EventArgs e) {
            dataGridView1.Rows.Clear();
            foreach (var product in currentCart.Values) {
                var actualProduct = productsDB[product.id];
                actualProduct.qty += product.qty;
            }
            currentCart.Clear();
            labelTotalPrice.Text = "0";
            labelGST.Text = "0";
            labelCGST.Text = "0";
        }

        private void ButtonDelete_Click(object sender, EventArgs e) {
            try {
                string text = textProductId.Text;
                textProductId.Text = "";
                int id = int.Parse(text);
                var product = currentCart[id];
                if (product == null) {
                    MessageBox.Show($"Not available", "Invalid Product!", MessageBoxButtons.OK);
                    return;
                }
                var actualProduct = productsDB[id];
                if (actualProduct == null) {
                    MessageBox.Show($"Not available", "Invalid Product!", MessageBoxButtons.OK);
                    return;
                }
                actualProduct.qty += 1;
                product.qty -= 1;
                if(product.qty == 0) {
                    currentCart.Remove(product.id);
                }
                RenderItems();
            } catch(Exception e2) {

            }
        }

        private void ShowReceipts(object sender, EventArgs e) {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private async void Button2_Click(object sender, EventArgs e) {
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            progressBar1.Value = 30;
            Form4 form = new Form4();
            await Task.Delay(3002);
            progressBar1.Value = 80;
            await Task.Delay(3002);
            progressBar1.Value = 80;
            await Task.Delay(2000);
            progressBar1.Visible = false;
            form.ShowDialog();
        }
    }
}
