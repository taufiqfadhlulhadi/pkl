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
    public partial class Form1 : Form
    {
        connection_class db = new connection_class();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            string passres = "";
            string permit = "";
            string query = "SELECT nama FROM [user] WHERE nama = '" + user + "' AND password = '" + pass + "'";
            MessageBox.Show(query);
            string result = null;
            try
            {
                db.connect(Application.StartupPath);
                db.sql_reader(query);
                while (db.read.Read())
                {
                    result = db.read.GetValue(0).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

                if (result != null && result == user)
                {
                main_menu main = new main_menu();
                this.Hide();
                main.ShowDialog();
                this.Show();
                textBox1.Text = "";
                textBox2.Text = "";
            }
                else
            {
                MessageBox.Show("Password/Username salah!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
                db.con.Close();
            }

        }
    }

