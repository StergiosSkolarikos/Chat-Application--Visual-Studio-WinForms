using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace EatrikiVideoCall
{
    public partial class Chat : MaterialForm
    {
        public string docfullname;
        public Chat()
        {
            InitializeComponent();
            fillComboBox1();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            //getDoctorName();
            //manager.Theme = MaterialSkinManager.Themes.LIGHT;

        }

        private void fillComboBox1()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from DocCategory", ConnectToDatabase.cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            DataRow row = ds.NewRow();
            row[0] = 0;
            row[1] = "-- Select --";
            ds.Rows.InsertAt(row, 0);
            comboBox1.DataSource = ds;
            
            comboBox1.DisplayMember = "descr";
            comboBox1.ValueMember = "id";
            

        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            //getDoctorName();
            ChatWindow ct = new ChatWindow("127.0.0.1", "80", "127.0.0.1", "81",comboBox2.Text);
            ct.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select id, concat(firstName, ' ', lastName) as name from Doctors where doccategory_id="+comboBox1.SelectedIndex+";", ConnectToDatabase.cnn);
            DataTable ds1 = new DataTable();
            da1.Fill(ds1);
            DataRow row = ds1.NewRow();
            row[0] = 0;
            row[1] = "-- Select --";
            ds1.Rows.InsertAt(row, 0);
            comboBox2.DataSource = ds1;

            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";
            

        }
        public void getDoctorName()
        {
            SqlCommand cmd = new SqlCommand("Select concat(firstname,' ',lastname) as fullname from Doctors where id=" + comboBox2.SelectedIndex + ";", ConnectToDatabase.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                docfullname = reader[0].ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
