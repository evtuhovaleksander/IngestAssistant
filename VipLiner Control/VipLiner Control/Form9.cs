using System;
using System.Windows.Forms;
using MediaInfoNET;

//using DirectShowLib;
//using DirectShowLib.DES;

namespace Ingest_Assistant
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();

            //  this.IsMdiContainer = true;
        }

        //public VideoFile GetVideoInfo(string inputPath)
        //{
        //    VideoFile vf = null;
        //    try
        //    {
        //        vf = new VideoFile(inputPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    GetVideoInfo(vf);
        //    return vf;
        //}
        //public void GetVideoInfo(VideoFile input)
        //{
        //    //set up the parameters for video info
        //    string Params = string.Format("-i {0}", input.Path);
        //    string output = RunProcess(Params);
        //    input.RawInfo = output;

        //    //get duration
        //    Regex re = new Regex("[D|d]uration:.((\\d|:|\\.)*)");
        //    Match m = re.Match(input.RawInfo);

        //    if (m.Success)
        //    {
        //        string duration = m.Groups[1].Value;
        //        string[] timepieces = duration.Split(new char[] { ':', '.' });
        //        if (timepieces.Length == 4)
        //        {
        //            input.Duration = new TimeSpan(0, Convert.ToInt16(timepieces[0]), Convert.ToInt16(timepieces[1]), Convert.ToInt16(timepieces[2]), Convert.ToInt16(timepieces[3]));
        //        }
        //    }
        //}


        private void button1_Click(object sender, EventArgs e)
        {
//            openFileDialog1.ShowDialog();

//var mediaDet = (IMediaDet)new MediaDet();
//DsError.ThrowExceptionForHR(mediaDet.put_Filename(openFileDialog1.FileName));

//int index;
//var type = Guid.Empty;
//for (index = 0; index < 1000 && type != MediaType.Video; index++)
//{
//    mediaDet.put_CurrentStream(index);
//    mediaDet.get_StreamType(out type);
//}

//double frameRate;
//mediaDet.get_FrameRate(out frameRate);

//var mediaType = new AMMediaType();
//mediaDet.get_StreamMediaType(mediaType);
//var videoInfo = (VideoInfoHeader)Marshal.PtrToStructure(mediaType.formatPtr, typeof(VideoInfoHeader));
//DsUtils.FreeAMMediaType(mediaType);
//var width = videoInfo.BmiHeader.Width;
//var height = videoInfo.BmiHeader.Height;

//double mediaLength;
//mediaDet.get_StreamLength(out mediaLength);
//var frameCount = (int)(frameRate * mediaLength);
//var duration = frameCount / frameRate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            var filename = openFileDialog1.FileName;
            //    DllImport("luanet.dll");


            var mdf = new MediaFile(filename);
            mdf.GetMediaInfo(true);
            mdf.GetMediaInfo(true);
            //     MessageBox.Show(mdf.Description);
            MessageBox.Show(mdf.MediaInfo_Text);
            MessageBox.Show(mdf.MediaInfo_HTML);
            //    MessageBox.Show(mdf.GetMediaInfo);
            richTextBox1.Text = mdf.MediaInfo_Text;


            //string all_info = mdf.MediaInfo_Text;
            //string video_vlock = all_info.Substring(all_info.IndexOf("Video"), all_info.IndexOf("Audio"));
            //string curent = video_vlock.Substring(video_vlock.IndexOf("Bit rate     "));
            //curent = curent.Substring(0, curent.IndexOf('\r'));
            //curent = curent.Substring(curent.IndexOf(':') + 1);
            //MessageBox.Show(curent);
            //MessageBox.Show(all_info.Length.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            richTextBox1.Text = Media_Info.get_info_complex(openFileDialog1.FileName);
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    GetVideoInfo();
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            // Data_Time_Span f=new Data_Time_Span();
            // f.TopLevel = false;
            //// f.Parent = panel1;
            // f.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
        }
    }
}