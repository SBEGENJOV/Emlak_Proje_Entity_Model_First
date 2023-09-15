using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace modalfirst_ornek
{
    public partial class customerPage : Form
    {
        public customerPage()
        {
            InitializeComponent();
        }
        Model1Container1 conn = new Model1Container1();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.customerSet.Where(x=>x.customerID==Form1.deger).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.homeSet.ToList();
            
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.plotSet.ToList();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            if (radioButton2.Checked)
            {
                textBox1.Tag = satir.Cells["homeID"].Value.ToString();
                textBox1.Text = satir.Cells["homeName"].Value.ToString();
                textBox2.Text = satir.Cells["homeAdres"].Value.ToString();
                textBox3.Text = satir.Cells["homePrice"].Value.ToString();
                textBox5.Text = satir.Cells["homeM2"].Value.ToString();
                comboBox1.Text= satir.Cells["customer_customerID"].Value.ToString();
            }
            else if(radioButton1.Checked) 
            {
                textBox1.Tag = satir.Cells["plotID"].Value.ToString();
                textBox1.Text = satir.Cells["plotName"].Value.ToString();
                textBox2.Text = satir.Cells["plotAdres"].Value.ToString();
                textBox3.Text = satir.Cells["plotPrice"].Value.ToString();
                textBox5.Text = satir.Cells["plotM2"].Value.ToString();
                comboBox1.Text = satir.Cells["customer_customerID"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                plot std = new plot();
                std.plotName = textBox1.Text;
                std.plotAdres = textBox2.Text;
                std.plotPrice = int.Parse(textBox3.Text);
                std.plotM2 = int.Parse(textBox5.Text);
                std.customer_customerID = Convert.ToInt32(comboBox1.Text);

                conn.plotSet.Add(std);
                conn.SaveChanges();
                dataGridView1.DataSource = conn.plotSet.ToList();
            }
            else if (radioButton2.Checked)
            {
                home std1 = new home();
                std1.homeName = textBox1.Text;
                std1.homeAdres = textBox2.Text;
                std1.homePrice = int.Parse(textBox3.Text);
                std1.homeM2 = int.Parse(textBox5.Text);
                std1.customer_customerID = Convert.ToInt32(comboBox1.Text);

                conn.homeSet.Add(std1);
                conn.SaveChanges();
                dataGridView1.DataSource = conn.plotSet.ToList();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var studentToDelete = conn.plotSet.FirstOrDefault(s => s.plotID == Convert.ToInt32(textBox1.Tag));
                conn.plotSet.Remove(studentToDelete);
                conn.SaveChanges();
            }
            else if (radioButton2.Checked)
            {
                var studentToDelete = conn.homeSet.FirstOrDefault(s => s.homeID == Convert.ToInt32(textBox1.Tag));
                conn.homeSet.Remove(studentToDelete);
                conn.SaveChanges();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.customerSet.Where(x => x.customerID == Form1.deger).ToList();
        }

        private void customerPage_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }
    }
}
