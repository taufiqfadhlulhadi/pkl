using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pkl
{
    class connection_class
    {
        public OleDbConnection con = new OleDbConnection();
        public OleDbCommand comd = new OleDbCommand();
        public OleDbDataReader read;
       
        public void read_query(string query)
        {
            try
            {
                con.Open();
                comd.Connection = con;
                comd.CommandText = query;
                read = comd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        public int connect(string path)
        {
            //oledb connector dan connection string
            try
            {
                con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                    + path + "\\database.accdb;";
                con.Open();
                return 1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public void sql_execution(string query)
        {
            //fungsi eksekusi query database
            //try
            //{
                comd = new OleDbCommand(query, con);
                //con.Open();
                comd.Connection = con;
                comd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("insert selesai");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(Convert.ToString(ex));
            //}
        }
        public void sql_reader(string query)
        {
            //fungsi reader database
            try
            {
                comd = new OleDbCommand(query);
                comd.Connection = con;
                //MessageBox.Show(query);
                read = comd.ExecuteReader();
                //MessageBox.Show("read selesai");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
