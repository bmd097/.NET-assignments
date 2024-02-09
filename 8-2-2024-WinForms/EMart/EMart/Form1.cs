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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private PersonDB personDB = new PersonDB();

        private void ButtonLogin_Click(object sender, EventArgs e) {
            String email = textEmail.Text;
            String password = textPassword.Text;
            var person = personDB.GetPerson(email, password);
            if(person != null) {
                Form2 form2 = new Form2(person);
                form2.HandleDestroyed += (o,i) => {
                    this.Close();
                };
                this.Hide();
                form2.ShowDialog();
            }
            Console.WriteLine(email + " " + password);
        }
    }
}
