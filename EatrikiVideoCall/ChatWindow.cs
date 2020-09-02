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
using System.Net;
using System.Net.Sockets;


namespace EatrikiVideoCall
{
    public partial class ChatWindow : MaterialForm
    {
        public static Socket sck;
        public static EndPoint epLocal, epRemote;
        public static byte[] buffer;
        public static string UserFullName;
        //public static string localIp = "192.168.1.3";
        //public static string remoteIp = "192.168.1.3";
        //public static string localPort = "80";
        //public static string remotePort = "81";


        public ChatWindow(string localIp,string localPort,string remoteIp,string remotePort,string userfullname)
        {
            InitializeComponent();
            UserFullName = userfullname;
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            listBox1.Items.Add("Connected IP:" + localIp + " Port:" + localPort);
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            epLocal = new IPEndPoint(IPAddress.Parse(localIp), Convert.ToInt32(localPort));
            sck.Bind(epLocal);
            epRemote = new IPEndPoint(IPAddress.Parse(remoteIp), Convert.ToInt32(remotePort));
            sck.Connect(epRemote);
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];
            sendingMessage = aEncoding.GetBytes(textBox1.Text);
            sck.Send(sendingMessage);
            listBox1.Items.Add("Me: " + textBox1.Text);
            textBox1.Text = "";
            

        }

      

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                byte[] receivedData = new byte[1500];
                receivedData = (byte[])aResult.AsyncState;
                //Converting byte to String
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string receiveMessage = aEncoding.GetString(receivedData);
                listBox1.Items.Add(UserFullName+" : " + receiveMessage);
                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        


    }
}
