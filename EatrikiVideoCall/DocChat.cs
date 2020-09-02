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

namespace EatrikiVideoCall
{
    public partial class DocChat : MaterialForm
    {
        public string userfullname;
        public DocChat()
        {
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            InitializeComponent();
            fillDataGrid();
            //getUserName();
        }
        private void fillDataGrid()
        {

            SqlDataAdapter da1 = new SqlDataAdapter("Select username,fullname,amka,email,mobile,date,hours,appcat from AppointmentsInfos where doc_account_id=" + ChatLogin.user_id + "and date='" + DateTime.Now.ToString("dd/MM/yyyy") + "' order by date desc,hours asc; ", ConnectToDatabase.cnn);
            DataTable dt = new DataTable();

            da1.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[7].Width = 50;

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            ChatWindow ct = new ChatWindow("127.0.0.1", "81", "127.0.0.1", "80", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            ct.Show();
        }
        public void getUserName()
        {
            SqlCommand cmd = new SqlCommand("Select concat(firstname,' ',lastname) as fullname from Users where id=" + ChatLogin.user_id + ";", ConnectToDatabase.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                userfullname = reader[0].ToString();
            }
        }
    }
}
