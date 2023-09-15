using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace modalfirst_ornek
{
    public partial class personel : Form
    {
        public personel()
        {
            InitializeComponent();
        }
        Model1Container1 conn = new Model1Container1();
        private void button6_Click(object sender, EventArgs e)
        {
            plot std = new plot();
            std.plotName = textBox10.Text;
            std.plotAdres = textBox9.Text;
            std.plotPrice = int.Parse(textBox8.Text);
            std.plotM2 = int.Parse(textBox7.Text);
            std.customer_customerID = int.Parse(textBox12.Text);

            conn.plotSet.Add(std);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.plotSet.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(textBox12.Text);
            var student = conn.plotSet.FirstOrDefault(s => s.plotID == sid);
            if (student != null)
            {
                student.plotName = textBox10.Text;
                student.plotAdres = textBox9.Text;
                student.plotPrice = int.Parse(textBox8.Text);
                student.plotM2 = int.Parse(textBox7.Text);
                student.customer_customerID = int.Parse(textBox6.Text);
                conn.SaveChanges();
                dataGridView1.DataSource = conn.plotSet.ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(textBox12.Text);
            var plotDel = conn.plotSet.FirstOrDefault(s => s.plotID ==sid);
            conn.plotSet.Remove(plotDel);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.plotSet.ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource=conn.homeSet.ToList();
            }
            else if (comboBox1.SelectedIndex==1)
            {
                
                dataGridView1.DataSource = conn.plotSet .ToList();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = conn.customerSet.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            home std = new home();
            std.homeName = textBox1.Text;
            std.homeAdres = textBox2.Text;
            std.homePrice = int.Parse(textBox3.Text);
            std.homeM2 = int.Parse(textBox4.Text);
            std.customer_customerID = int.Parse(textBox5.Text);

            conn.homeSet.Add(std);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.homeSet.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(textBox6.Text);
            var student = conn.homeSet.FirstOrDefault(s => s.homeID == sid);
            if (student != null)
            {
                student.homeName = textBox10.Text;
                student.homeAdres = textBox9.Text;
                student.homePrice = int.Parse(textBox8.Text);
                student.homeM2 = int.Parse(textBox7.Text);
                student.customer_customerID = int.Parse(textBox5.Text);
                conn.SaveChanges();
                dataGridView1.DataSource = conn.homeSet.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(textBox11.Text);
            var homeDel = conn.homeSet.FirstOrDefault(s => s.homeID == sid);
            conn.homeSet.Remove(homeDel);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.homeSet.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            customer std = new customer();
            std.customerName = textBox18.Text;
            std.customerAge =int.Parse(textBox17.Text);
            std.customerPhone =textBox16.Text;
            std.customerPW = textBox15.Text;

            conn.customerSet.Add(std);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.customerSet.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(textBox14.Text);
            var student = conn.customerSet.FirstOrDefault(s => s.customerID == sid);
            if (student != null)
            {
                student.customerName = textBox18.Text;
                student.customerAge = int.Parse(textBox17.Text);
                student.customerPhone = textBox16.Text;
                student.customerPW = textBox15.Text;

                conn.SaveChanges();
                dataGridView1.DataSource = conn.customerSet.ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(textBox14.Text);
            var cusDel = conn.customerSet.FirstOrDefault(s => s.customerID == sid);
            conn.customerSet.Remove(cusDel);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.customerSet.ToList();
        }

        private void personel_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            this.Size = new System.Drawing.Size(760, 580);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox1.Location = new System.Drawing.Point(10, 360);
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox2.Location = new System.Drawing.Point(10, 360);
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                groupBox3.Location = new System.Drawing.Point(10, 360);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex==1)
            {
                var enYas = conn.customerSet.OrderBy(s => s.customerAge).Take(1);
               dataGridView1.DataSource=enYas.ToList();
            }
            else if (comboBox3.SelectedIndex == 0)
            {
                var enGen = conn.customerSet.OrderByDescending(s => s.customerAge).Take(1);
                dataGridView1.DataSource = enGen.ToList();
            }
            else if (comboBox3.SelectedIndex==2)
            {
                var query = from c in conn.customerSet
                            join emp in conn.employeSet on c.employe_employeID equals emp.employeID
                            select new { c.customerName, emp.employeName };
                dataGridView1.DataSource=query.ToList();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex==0)
            {
                var enYas = conn.employeSet.OrderBy(s => s.employeAge);
                dataGridView1.DataSource = enYas.ToList();
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                var enMass = conn.employeSet.OrderBy(s => s.employeWope);
                dataGridView1.DataSource = enMass.ToList();
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                var query = from emp in conn.employeSet
                            join
                            cos in conn.customerSet on emp.employeID equals cos.employe_employeID
                            group cos by new { emp.employeName, cos.employe_employeID } into grp
                            select new
                            {
                                Saticiİsim=grp.Key.employeName,
                                toplam=grp.Count()
                            };
                dataGridView1.DataSource = query.ToList();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex==0)
            {
                var evPah = conn.homeSet.OrderByDescending(s => s.homePrice);
                dataGridView1.DataSource= evPah.ToList();
            }
            else if(comboBox5.SelectedIndex==1)
            {
                var evm2 = conn.homeSet.OrderByDescending(s => s.homeM2);
                dataGridView1.DataSource = evm2.ToList();
            }
            else if (comboBox5.SelectedIndex == 2)
            {
                var evKim = from hom in conn.homeSet
                            join cus in conn.customerSet on hom.customer_customerID equals cus.customerID
                            select new
                            {
                                cus.customerName,
                                hom.customer_customerID
                            };
                dataGridView1.DataSource=evKim.ToList();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 0)
            {
                var evPah = conn.plotSet.OrderByDescending(s => s.plotPrice);
                dataGridView1.DataSource = evPah.ToList();
            }
            else if (comboBox6.SelectedIndex == 1)
            {
                var evm2 = conn.plotSet.OrderByDescending(s => s.plotM2);
                dataGridView1.DataSource = evm2.ToList();
            }
            else if (comboBox6.SelectedIndex == 2)
            {
                var evKim = from plo in conn.plotSet
                            join cus in conn.customerSet on plo.customer_customerID equals cus.customerID
                            select new
                            {
                                cus.customerName,
                                plo.customer_customerID
                            };
                dataGridView1.DataSource = evKim.ToList();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }
    }
}
