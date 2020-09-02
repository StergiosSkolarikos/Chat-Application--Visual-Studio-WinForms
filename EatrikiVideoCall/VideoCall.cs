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

namespace EatrikiVideoCall
{
    public partial class VideoCall : MaterialForm
    {
        public VideoCall()
        {
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            //axVideoChatServer1.InitServer(55539, 300);
            axVideoChatSender1.Connect("localhost", 80);
            axVideoChatSender1.VideoDevice = 0;
            axVideoChatSender1.VideoFormat = 0;
            axVideoChatSender1.AudioDevice = 0;
            //axVideoChatSender1.FrameRate = 15;
            //axVideoChatSender1.VideoBitrate = 50000;
            //axVideoChatSender1.AudioQuality = 0;
            //axVideoChatSender1.AudioComplexity = 0;
            axVideoChatSender1.SendVideoStream = true;
            axVideoChatSender1.SendAudioStream = true;
            
            axVideoChatReceiver1.ReceiveVideoStream = true;
            axVideoChatReceiver1.ReceiveAudioStream = true;
            axVideoChatReceiver1.Listen("localhost", 80);

        }

        
    }
}
