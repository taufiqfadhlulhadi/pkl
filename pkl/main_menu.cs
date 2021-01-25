using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pkl
{
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input form_input = new input();
            this.Hide();
            form_input.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            laporan form_laporan = new laporan();
            this.Hide();
            form_laporan.ShowDialog();
            this.Show();
        }
    }
}
