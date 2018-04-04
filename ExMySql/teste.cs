using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExMySql
{
    public partial class FrmTeste : Form
    {
        public FrmTeste()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TEste");
            textBox1.Clear();
        }

        private void radioButton1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Ola");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("CheckedChanged");
            Form1 f = new Form1();
            f.Show();
        }
    }
}
