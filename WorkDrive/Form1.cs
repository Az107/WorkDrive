using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app2test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Program.Create();
            //((Button)sender).Visible = false;
            Form2 form2 = new Form2();
            form2.Show();
            button1.Enabled = false;
            button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.Umount();
            button1.Enabled = true;
            button2.Enabled = false;


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resutl = MessageBox.Show("the workspace will close, continue?","WorkSpace",MessageBoxButtons.YesNo);
            if (resutl == DialogResult.Yes)
            {
                Program.Umount();

            }
            else
            {
                e.Cancel = true;
            }

        }
    }
}
