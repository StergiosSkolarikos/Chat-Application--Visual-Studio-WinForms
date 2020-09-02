using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data.SqlClient;

namespace EatrikiVideoCall
{
    public partial class ChatLogin : Form
    {
        public static int usertype;
        public static int doc_id;
        public static int user_id;
        public static string user_fullname;
        public static string doc_fullname;
        public ChatLogin()
        {
            InitializeComponent();
            //MaterialSkinManager manager = MaterialSkinManager.Instance;
            //manager.AddFormToManage(this);
            ConnectToDatabase.connectToDatabase();
            textBox2.UseSystemPasswordChar = true;
        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select id,username,password,usertype from All_Accounts where username='" + textBox1.Text + "' and password='" + textBox2.Text + "';", ConnectToDatabase.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                usertype = Int32.Parse(reader[3].ToString());
                user_id = Int32.Parse(reader[0].ToString());
                if (usertype == 1)
                {
                    
                    reader.Close();
                    DocChat dc = new DocChat();
                    //ChatWindow ct = new ChatWindow("127.0.0.1", "81", "127.0.0.1", "80");
                    ConnectToDatabase.cnn.Close();
                    dc.Show();
                    this.Hide();

                }
                else if (usertype == 2)
                {
                    
                    reader.Close();
                    Chat ch = new Chat();
                    ConnectToDatabase.cnn.Close();
                    ch.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Account is wrong!");
                }


            }
        }
        private void StartChat()
        {

        }
    }
}
