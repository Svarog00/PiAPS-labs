using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoapFraemwork
{
    public partial class Form1 : Form
    {
        SoapClient client;
        
        public Form1()
        {
            client = new SoapClient();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                textBox3.Text = CheckParse(textBox1.Text, textBox2.Text, client.Add);
            }
            else if (radioButton2.Checked)
            {
                textBox3.Text = CheckParse(textBox1.Text, textBox2.Text, client.Subtract);
            }
            else if (radioButton3.Checked)
            {
                textBox3.Text = CheckParse(textBox1.Text, textBox2.Text, client.Multiply);
            }
            else if (radioButton4.Checked)
            {
                textBox3.Text = CheckParse(textBox1.Text, textBox2.Text, client.Divide);
            }
            else
            {
                textBox3.Text = "Error";
            }

        }

        private string CheckParse(string text1, string text2, Func<int, int, int> Meth)
        {
            int tmp1;
            int tmp2;

            if (int.TryParse(text1, out tmp1) && int.TryParse(text2, out tmp2))
            {
               return Meth(tmp1, tmp2).ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
