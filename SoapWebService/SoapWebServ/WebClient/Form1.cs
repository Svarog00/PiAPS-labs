using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebClient
{
    public partial class Form1 : Form
    {
        SoapClient client;
        public Form1()
        {
            InitializeComponent();
            client = new SoapClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
               richTextBox1.Text = client.ShowRaces(textBox1.Text, textBox2.Text);
            }
            else if (radioButton2.Checked)
            {
                richTextBox1.Text = client.CheckTickets(textBox1.Text, textBox2.Text, dateTimePicker1.Value);
            }
            else if (radioButton3.Checked)
            {
                richTextBox1.Text = client.BuyTicket(textBox1.Text, textBox2.Text, dateTimePicker1.Value, Convert.ToInt32(textBox4.Text));
            }
            else
            {
                MessageBox.Show("Choose smth", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            dateTimePicker1.Enabled = false;
            textBox4.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox4.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox4.Enabled = true;
        }
    }
}
