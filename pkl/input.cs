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
    public partial class input : Form
    {
        connection_class db = new connection_class();
        TimeSpan lamapadam = TimeSpan.Parse("00:00");
        string timetrip;
        string timeopen;
        public input()
        {
            InitializeComponent();
            isi_combobox();
        }

        public void ambil_data(string field, string table, ComboBox combobox)
        {
            string query = "SELECT " + field + " FROM [" + table + "];";
            db.connect(Application.StartupPath);
            db.sql_reader(query);
            try
            {
                while (db.read.Read())
                {
                    combobox.Items.Add(db.read.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        public void isi_combobox()
        {
            string field = "area";
            string table = "area";
            ambil_data(field, table, AreacomboBox);
            field = "pltd";
            table = "nama_sumber";
            ambil_data(field, table, SumbercomboBox);
            field = "nama_penyulang";
            table = "penyulang";
            ambil_data(field, table, PenyulanngcomboBox);
        }

        private void hasilBtn_Click(object sender, EventArgs e)
        {
            int ampere = Convert.ToInt32(bebanopenTxtbox.Text);
            int lamapadam1 = Convert.ToInt32(lamapadam.TotalMinutes.ToString());
            MessageBox.Show(lamapadam1.ToString());
            double hasil;
            hasil = ampere * 20000 * (Math.Sqrt(3)) * lamapadam1 * 0.85 * 1000;
            if (IndikasicomboBox.Text == "OCR" ||
                IndikasicomboBox.Text == "GFR" ||
                IndikasicomboBox.Text == "ARC" ||
                IndikasicomboBox.Text == "FMJ")
            {
                ggnTxtbox.Text = Convert.ToString(hasil);
                harTxtbox.Text = "0.00";
                dftTxtbox.Text = "0.00";
                boTxtbox.Text = "0.00";
            }
            else if (IndikasicomboBox.Text == "HAR")
            {
                harTxtbox.Text = Convert.ToString(hasil);
                ggnTxtbox.Text = "0.00";
                dftTxtbox.Text = "0.00";
                boTxtbox.Text = "0.00";
            }
            else if (IndikasicomboBox.Text == "DFT")
            {
                dftTxtbox.Text = Convert.ToString(hasil);
                ggnTxtbox.Text = "0.00";
                harTxtbox.Text = "0.00";
                boTxtbox.Text = "0.00";
            }
            else if (IndikasicomboBox.Text == "OB" ||
                    IndikasicomboBox.Text == "UFR" ||
                    IndikasicomboBox.Text == "UVLS" ||
                    IndikasicomboBox.Text == "OLS")
            {
                boTxtbox.Text = Convert.ToString(hasil);
                ggnTxtbox.Text = "0.00";
                harTxtbox.Text = "0.00";
                dftTxtbox.Text = "0.00";
            }
            else
            {
                ggnTxtbox.Text = "0.00";
                harTxtbox.Text = "0.00";
                dftTxtbox.Text = "0.00";
                boTxtbox.Text = "0.00";
            }
        }


        private void simpanBtn_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            try
            {
                string query = "INSERT INTO [data_listrik] VALUES ('" + AreacomboBox.Text + "', '" + SumbercomboBox.Text + "', '" + PenyulanngcomboBox.Text + "', '" + timetrip + "', '" + timeopen + "', '" + bebanopenTxtbox.Text + "', '" + closeTxtbox.Text + "', '" + bebancloseTxtbox.Text + "', '" + padamTxtbox.Text + "', '" + IndikasicomboBox.Text + "', '" + GangguancomboBox.Text + "', '" + keteranganTxtbox.Text + "', '" + ggnTxtbox.Text + "', '" + harTxtbox.Text + "', '" + boTxtbox.Text + "', '" + lamapadam.ToString() + "', '" + arusTxtbox.Text + "', '" + lokasiTxtbox.Text + "', '" + dispatcherTxtbox.Text + "', '" + today.ToString("dd/mmmm/yyyy") + "');";
                MessageBox.Show(query);
                db.connect(Application.StartupPath);
                db.sql_execution(query);
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            AreacomboBox.SelectedItem = -1;
            SumbercomboBox.SelectedItem = -1;
            PenyulanngcomboBox.SelectedItem = -1;
            tripTxtbox.Text = "";
            openTxtbox.Text = "";
            bebancloseTxtbox.Text = "";
            closeTxtbox.Text = "";
            bebanopenTxtbox.Text = "";
            padamTxtbox.Text = "";
            IndikasicomboBox.SelectedItem = -1;
            GangguancomboBox.SelectedItem = -1;
            keteranganTxtbox.Text = "";
            ggnTxtbox.Text = "";
            harTxtbox.Text = "";
            dftTxtbox.Text = "";
            boTxtbox.Text = "";
            arusTxtbox.Text = "";
            lokasiTxtbox.Text = "";
            dispatcherTxtbox.Text = "";
        }

        private void closeTxtbox_Enter(object sender, EventArgs e)
        {
            TimeSpan close = TimeSpan.Parse("00:00");
            TimeSpan open = TimeSpan.Parse("00:00");
            TimeSpan trip = TimeSpan.Parse("00:00");
            timetrip = tripTxtbox.Text;
            if (timetrip != "")
            {
                trip = new TimeSpan(int.Parse(timetrip.Split(':')[0]),    // hours
               int.Parse(timetrip.Split(':')[1]),    // minutes
               0);
            }

            timeopen = openTxtbox.Text;
            if (timeopen != "")
            { 
                open = new TimeSpan(int.Parse(timeopen.Split(':')[0]),    // hours
                               int.Parse(timeopen.Split(':')[1]),    // minutes
                               0);
            }

            string timeclose = closeTxtbox.Text;
            if(timeclose != "")
            {
                close = new TimeSpan(int.Parse(timeclose.Split(':')[0]),    // hours
               int.Parse(timeclose.Split(':')[1]),    // minutes
               0);
                
            }
            try
            {
                if (timeopen == "")
                {
                    lamapadam = close - trip;
                    padamTxtbox.Text = lamapadam.ToString(@"hh\:mm");
                    timeopen = "-";
                }
                else if (timetrip == "")
                {
                    lamapadam = close - open;
                    padamTxtbox.Text = lamapadam.ToString(@"hh\:mm");
                    timetrip = "-";
                }
            }
            catch
            {

            }
        }
    }
}
