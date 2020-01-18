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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Program.Create();
            //((Button)sender).Visible = false;
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.Umount();
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
