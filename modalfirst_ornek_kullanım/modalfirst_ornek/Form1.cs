using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modalfirst_ornek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true; groupBox2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true; groupBox1.Visible = false;
        }

        public static int deger;
        Model1Container1 conn = new Model1Container1();
        public bool loginUser(string userName, string passw)
        {
            var query = from user in conn.customerSet
                        where user.customerName == userName && user.customerPW == passw
                        select user.customerID;
            foreach (var agu in query)
            {
                deger = agu;
            }
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool loginEmploye(string userName, string passw)
        {
            var query = from user in conn.employeSet
                        where user.employeName == userName && user.employePW == passw
                        select user.employeID;
            foreach (var firstName in query)
            {
                deger = firstName;
            }
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (loginUser(textBox1.Text, textBox2.Text))
            {
                customerPage go = new customerPage();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bilgilerinizi Kontrol edin");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loginEmploye(textBox4.Text, textBox3.Text))
            {
                personel go = new personel();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girilen Bilgiler Yalnış");
            }
        }
    }
}
