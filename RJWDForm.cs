using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegioJetWD
{
    public partial class RJWDForm : Form
    {
        static RegiojetWD rjwd = new RegiojetWD();
        static Mailer mailer = new Mailer();
        
        public RJWDForm()
        {
            InitializeComponent();
        }

        private void RJWDForm_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            rjwd.SetupTest(textBox1.Text);
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
            rjwd.TeardownTest();
            rjwd = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rjwd.Refresh();
            List<int> listSpaces = rjwd.TheRegiojetWDTest();
            
            for (int i = 0; i < listSpaces.Count; i++)
            {
                if (i == 0)
                {
                    textBox2.Text = listSpaces[i].ToString();
                    if (listSpaces[i] > 0 && checkBox1.Checked)
                        mailer.sendit(textBox7.Text);
                }

                if (i == 1)
                {
                    textBox3.Text = listSpaces[i].ToString();
                    if (listSpaces[i] > 0 && checkBox2.Checked)
                        mailer.sendit(textBox7.Text);
                }

                if (i == 2)
                {
                    textBox4.Text = listSpaces[i].ToString();
                    if (listSpaces[i] > 0 && checkBox3.Checked)
                        mailer.sendit(textBox7.Text);
                }

                if (i == 3)
                {
                    textBox5.Text = listSpaces[i].ToString();
                    if (listSpaces[i] > 0 && checkBox4.Checked)
                        mailer.sendit(textBox7.Text);
                }

                if (i == 4)
                {
                    textBox6.Text = listSpaces[i].ToString();
                    if (listSpaces[i] > 0 && checkBox5.Checked)
                        mailer.sendit(textBox7.Text);
                }
            }
        }
    }
}
