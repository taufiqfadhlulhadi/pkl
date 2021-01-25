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
    public partial class laporan : Form
    {
        connection_class db = new connection_class();
        public laporan()
        {
            InitializeComponent();
        }

        public void load()
        {
            ListViewItem lv;
            string query = "SELECT * FROM ['data_listrik']";
            db.connect(Application.StartupPath);
            try
            {
                db.sql_reader(query);
                while(db.read.Read())
                {
                    lv = listView1.Items.Add(db.read["area"].ToString());
                    lv.SubItems.Add(db.read["id_pltd"].ToString());
                    lv.SubItems.Add(db.read["id_penyulang"].ToString());
                    lv.SubItems.Add(db.read["trip"].ToString());
                    lv.SubItems.Add(db.read["open1"].ToString());
                    lv.SubItems.Add(db.read["beban_amp1"].ToString());
                    lv.SubItems.Add(db.read["close1"].ToString());
                    lv.SubItems.Add(db.read["beban_amp2"].ToString());
                    lv.SubItems.Add(db.read["lama_padam"].ToString());
                    lv.SubItems.Add(db.read["indikasi"].ToString());
                    lv.SubItems.Add(db.read["sebab_ganggu"].ToString());
                    lv.SubItems.Add(db.read["ggn"].ToString());
                    lv.SubItems.Add(db.read["har"].ToString());
                    lv.SubItems.Add(db.read["dft"].ToString());
                    lv.SubItems.Add(db.read["ob_ufr_ovls_ols"].ToString());
                    lv.SubItems.Add(db.read["arus_ganggu"].ToString());
                    lv.SubItems.Add(db.read["lokasi"].ToString());
                    lv.SubItems.Add(db.read["dispatcher"].ToString());
                    lv.SubItems.Add(db.read["tgl_input"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
