using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;


namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //int x;
        //int y;
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x0002;//模拟鼠标移动
        private readonly int MOUSEEVENTF_MOVE = 0x0001;//模拟鼠标左键按下
        private readonly int MOUSEEVENTF_LEFTUP = 0x0004;//模拟鼠标左键抬起
        private readonly int MOUSEEVENTF_ABSOLUTE = 0x8000;//鼠标绝对位置
        //private readonly int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        //private readonly int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        //private readonly int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        //private readonly int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 
        

        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

            // 测试用代码
        private void buttonTest_Click(object sender, EventArgs e)
        {
            //x = 553;
            //y = 368;

            //textBoxTest.Text = ColorToString(GetColor(x, y));
            //AlbatrossClick(533, 368);
            ScanHP();
        }


        //鼠标点击模拟函数
        private int AlbatrossClick(int x,int y) //传入参数要做 参数 * 65535 / width or height处理
        {
            Random ran = new Random();
            int RandKey = ran.Next(1, 5);
            int RandKey2 = ran.Next(1, 2);
            if (RandKey2 == 1)
            {
                RandKey = -RandKey;
            }
            x = x + RandKey;
            y = y + RandKey;
            //mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            //mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x , y , 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x , y , 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x , y , 0, 0);//抬起
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = new Image<Bgr, byte>(@"D:\src.jpg");//从文件加载图片
            imageBox1.Image = image;//显示图片
        }

        private void FlipButton_Click(object sender, EventArgs e)
        {
            //if (imageBox1.Image != null)
            //{
            //    var image = (Image<Bgr, Byte>)imageBox1.Image;
            //    image._Flip(FlipType.Horizontal);//翻转图像
            //    imageBox1.Image = image;
            //}
            
            Image < Bgr, byte> a = new Image<Bgr, byte>(@"d:\src.jpg");
         
            Image < Bgr, byte> b = new Image<Bgr, byte>(@"d:\file.jpg");
          
            Image < Gray, float> c = new Image<Gray, float>(a.Width, a.Height);

            c = a.MatchTemplate(b, TemplateMatchingType.CcorrNormed);

            // imageBox2.Image = c;
           
            double min = 0, max = 0;
            
            Point maxp = new Point(0, 0);
           
            Point minp = new Point(0, 0);
        
            CvInvoke.MinMaxLoc(c, ref min, ref max, ref minp, ref maxp);

            int x = maxp.X + (b.Width / 2);

            int y = maxp.Y + (b.Height / 2);

            textBoxTest2.Text = x.ToString();

            textBoxTest3.Text = y.ToString();

            x = x * 65535 / a.Width; y = y * 65535 / a.Height;

            AlbatrossClick(x, y);

            //CvInvoke.Normalize(c, c);

            CvInvoke.Rectangle(a, new Rectangle(maxp, new Size(b.Width, b.Height)), new MCvScalar(0, 0, 255), 3);

            imageBox1.Image = a;

        }

        //private void processframe(object sender, EventArgs arg)

        //{

        //    Image<Bgr, Byte> frame = cam.QueryFrame();

        //    Image<Gray, Byte> Ecanny = frame.Convert<Gray, Byte>();

        //    CvInvoke.cvCanny(Ecanny.Ptr, Ecanny.Ptr, 50, 150, 3);

        //    //cvCanny是opencv中常用的函数，原本的参数应该是IplImage*类型，这里使用Intpr代替，即Ecanny.ptr

        //    pictureBox1.Image = Ecanny.Bitmap;

        //}

        //public static Bitmap captureControl(Control control)
        //{
        //    //调用API截屏  
        //    IntPtr hSrce = GetWindowDC(control.Handle);
        //    IntPtr hDest = CreateCompatibleDC(hSrce);
        //    IntPtr hBmp = CreateCompatibleBitmap(hSrce, control.Width, control.Height);
        //    IntPtr hOldBmp = SelectObject(hDest, hBmp);
        //    if (BitBlt(hDest, 0, 0, control.Width, control.Height, hSrce, 0, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt))
        //    {
        //        Bitmap bmp = Image.FromHbitmap(hBmp);
        //        SelectObject(hDest, hOldBmp);
        //        DeleteObject(hBmp);
        //        DeleteDC(hDest);
        //        ReleaseDC(control.Handle, hSrce);
        //        // bmp.Save(@"a.png");  
        //        // bmp.Dispose();  
        //        return bmp;
        //    }
        //    return null;

        //}

        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32")]
        public static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        public Color GetColor(int x, int y)
        {
            //也许有用
         

            IntPtr hdc = GetDC(IntPtr.Zero); uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF), (int)(pixel & 0x0000FF00) >> 8, (int)(pixel & 0x00FF0000) >> 16);
            textBoxColor.Text = color.ToString();
            //Albatross.albatross = (int)pixel;
            //textBoxAlbatross.Text = Albatross.albatross.ToString();
            //Albatross.R =(int)color.R;
            //Albatross.G = (int)color.G;
            //Albatross.B = (int)color.B;
            return color;
        }

        public static string ColorToString(System.Drawing.Color color)
        {
            string result;
            if (color.IsKnownColor || color.IsNamedColor || color.IsSystemColor)
            {
                result = color.Name;
            }
            else
            {
                result = string.Concat("#", color.ToArgb().ToString("X").Substring(2));
            }
            return result;
        }


        private void ScanHP()
        {
            
            int ScanExit = 1;
           //第一艘船
            if (Compare1(359,445, 186, 8, 8))//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
           ScanExit = 0;
                FixBoat(1);
            }
          
            //第二艘船
            if (Compare1(493, 445, 186, 8, 8))//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
         ScanExit = 0;
                FixBoat(2);
            }
           

           //第三艘船
            if (Compare1(625, 445, 186, 8, 8))//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(3);
            }
            

            //第四艘船
            if (Compare1(757, 445, 186, 8, 8))//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(4);
            }
          

            //第五艘船
            if (Compare1(891, 445, 186, 8, 8))//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(5);
            }
           

            //第六艘船
            if (Compare1(1024,445,186,8,8))//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(6);
            }
            

            if (ScanExit == 1)
            {
                return;
            }
            else
            {
                
                //textBoxHPRedStart.Text = Albatross.RedBloodShipNumber.ToString();
                ScanHP();
            }

        }

        private void FixBoat(int l)
        {
            //x = 1260;
            //y = 220;
            AlbatrossClick(1260, 220);
            Delay(1000);

            if (l == 1)
            {
            //    x = 282;
            //    y = 335;
                AlbatrossClick(282, 335); 
                Delay(1000);
                AlbatrossClick(1032, 172);
                Delay(1000);
            }
            else
            {
                if (l == 2)
                {
                    AlbatrossClick(414, 335);
                    Delay(1000);
                    AlbatrossClick(1032, 172);
                    Delay(1000);               
                }
                else
                {
                    if (l == 3)
                    {
                        AlbatrossClick(545, 335);
                        Delay(1000);
                        AlbatrossClick(1032, 172);
                        Delay(1000);
                    }
                    else
                    {
                        if (l == 4)
                        {
                            AlbatrossClick(680, 335);
                            Delay(1000);
                            AlbatrossClick(1032, 172);
                            Delay(1000);
                        }
                        else
                        {
                            if (l == 5)
                            {
                                AlbatrossClick(808, 335);
                                Delay(1000);
                                AlbatrossClick(1032, 172);
                                Delay(1000);
                            }
                            else
                            {
                                if (l == 6)
                                {
                                    AlbatrossClick(940, 335);
                                    Delay(1000);
                                    AlbatrossClick(1032, 172);
                                    Delay(1000);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void buttonScanHP_Click(object sender, EventArgs e)
        {
            ScanHP();
        }
        public void Supply()
        {
            int x = 1258;
            int y = 112;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(1000);

            x = 893;
            y = 573;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(1000);

            return;
        }
                
        
        //延时函数
        private void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权            
            }
            return;
        }







        private void ChuZhengKaiShi()
        {
            //海域选择完毕 出征开始
            int x = 672;
            int y = 713;
            AlbatrossClick(x, y);
        }

        private void ZhanDouKaiShi()
        {
            //索敌成功 开始战斗
            int x = 929;
            int y = 659;
            AlbatrossClick(x, y);
        }

        //选择海域
        private void XuanZeHaiYu()
        {
            int x = 766;
            int y = 420;
            AlbatrossClick(x, y);

          
        }

      
        private void XuanZhenXing()
        {
            //选阵型啦
            //if (radioButton1.Checked == true)
            //{
                int x = 1171;
                int y = 275;
                AlbatrossClick(x, y);
        //    }
        //    if (radioButton2.Checked == true)
        //    {
        //        int x = 1086;
        //        int y = 671;
        //        AlbatrossClick(x, y);
        //    }
        //    else
        //    {
        //        int x = 1171;
        //        int y = 275;
        //        AlbatrossClick(x, y);
        //    }
        }

        private void YeZhanTuRu()
        {
            //夜战突入吗
            int x = 802;
            int y = 371;
            AlbatrossClick(x, y);
            Delay(10000);
            AlbatrossClick(x, y);
        }

        private void ZhanShuPingJia()
        {
            //战术评价
            int x = 802;
            int y = 371;
            AlbatrossClick(x, y);
        }

        private void MVPPingJia()
        {
            //MVP评价
            int x = 1206;
            int y = 711;
            AlbatrossClick(x, y);
         }

        
        private void HuoDeXinChuan()
        {
            //获得新船
            int x = 1206;
            int y = 711;
            AlbatrossClick(x, y);
        }

        private void FanHuiMuGang()
        {
            //反回母港
            int x = 1006;
            int y = 600;
            AlbatrossClick(x, y);
            Delay(1000);
            x = 1008;
            y = 622;
            AlbatrossClick(x, y);
            x = 801;
            y = 375;
            AlbatrossClick(x, y);
        }

        private void MuGangChuZheng()
        {

            int x = 1007;
            int y = 273;
            AlbatrossClick(x, y);
        }
        private void Test()
        {
            //远征

            if (Compare1(970, 139, 255, 255, 255))
            {

                timerMain.Enabled = false;
                int x = 1007;
                int y = 273;
                AlbatrossClick(x, y);
                Delay(1000);


                //拉到远征第一页
                //x = 278;
                //y = 692;
                //int i;
                //for (i = 1; i > 5; i++)
                //{
                //    AlbatrossClick(x, y);
                //    Delay(50);

                //}
                //ShouFaYuanZheng();
                ShouFaYuanZheng();
                timerMain.Enabled = true;

            }
            else {
                //出征开始
                int x = 1007;
                int y = 273;
                AlbatrossClick(x, y);
                Delay(1000);
                AlbatrossClick(x, y);
            }
        }

        //远征-逻辑1
        public void ShouFaYuanZheng()
        {
            timerMain.Enabled = false;
            switch (PanDuanYuanZheng())
            {
                
                case "1":
                    YuanZheng(1);
                    
                   break;
                    
                case "2":
                    YuanZheng(2);

                    break;
                case "3":
                    YuanZheng(3);

                    break;
                case "4":
                    YuanZheng(4);

                    break;
                case "5":
                    Delay(5000);
                    AlbatrossClick(130, 676);
                    break;
                default:
                    Delay(5000);
                    AlbatrossClick(130, 676);
                    break;

            }
            timerMain.Enabled = true;
        }     
        //远征-逻辑2
        public string PanDuanYuanZheng()
        {
           

            //蓝色条件 
            // if (Compare1(1246,598,0,146,190))


            //红色条件1
            if (Compare1(1255, 144, 173, 73, 0))
            {
                return "1";
            }
            //红色条件2
            if (Compare1(1253,295, 173, 73, 0))
            {
                return "2";
            }
            //红色条件3
            if (Compare1(1257, 446, 173, 73, 0))
            {
                return "3";
            }
            //红色条件4
            if (Compare1(1250, 600, 173, 73, 0))
            {
                return "4";
            }
            
            return "5";
        }
        //public void MainStart()
        //    {
        //    Thread th = new Thread(new ThreadStart(XunHuan));
        //    th.Start();

            //远征-逻辑3
        public void YuanZheng(int h)
        {
            if (h == 1)
            {
                int x = 1255;
                int y = 144;

                YuanZhengCaoZuo(x, y);
            }
            if (h == 2)
            {
                int x = 1253;
                int y = 295;
                YuanZhengCaoZuo(x, y);
            }
            if (h == 3)
            {
                int x = 1257;
                int y = 446;
                YuanZhengCaoZuo(x, y);
            }
            if (h == 4)
            {
                int x = 1255;
                int y = 600;
                YuanZhengCaoZuo(x, y);
            }
        }

        //远征-逻辑....逻辑你大爷啊用得着这么多吗?
        public void YuanZhengCaoZuo(int x,int y)
        {
            
            Delay(5000);
            AlbatrossClick(x, y);
            Delay(5000);
            AlbatrossClick(x, y);
            Delay(5000);
            AlbatrossClick(x, y);
            Delay(5000);
            //2
            x = 644;
            y = 525;
            AlbatrossClick(x, y);
            Delay(2000);
            //出征
            x = 681;
            y = 713;
            AlbatrossClick(x, y);
            Delay(2000);

            //3
            x = 774;
            y = 525;
            AlbatrossClick(x, y);
            Delay(2000);
            //出征
            x = 681;
            y = 713;
            AlbatrossClick(x, y);
            Delay(2000);

            //4
            x = 902;
            y = 525;
            AlbatrossClick(x, y);
            Delay(1000);
            //出征
            x = 681;
            y = 713;
            AlbatrossClick(x, y);
            
            Delay(5000);
            AlbatrossClick(130, 676);
        }

        private void GameRestart()
        {
           
            AlbatrossClick(306,200);
           
        }



        //    //Task.Factory.StartNew(new Action(() =>
        //    //{
        //    //    while (true)
        //    //    {
        //    //        if (Exit == true)
        //    //        {
        //    //            break;
        //    //        }
        //    //    }                
        //    //    //switch 
        //    //}));

        //    th.Join();//主线程等待辅助线程结束  
        //}

        //public void XunHuan()
        //{
        //    while (true)
        //    {
        //        if (Exit == true)
        //        {
        //            break;
        //        }

        //        //listBox1.Invoke((Action)(() =>
        //        //{
        //        //    listBox1.Items.Add(DateTime.Now + "  RecConext>" + Encoding.GetEncoding("GB2312").GetString(result, 0, receiveLength));
        //        //}));
        //        textBoxAlbatross.Invoke((Action)(() =>
        //        {
        //            textBoxAlbatross.Text = "waht?";
        //        }));
        //    }
        //}

        private void buttonMainStart_Click(object sender, EventArgs e)
        {
            timerMain.Enabled=true;
        }

        private void buttonMainExit_Click(object sender, EventArgs e)
        {
            timerMain.Enabled = false;

        }

        //大概是
        private void timer1_Tick(object sender, EventArgs e)
        {
           MainStart();
        }

        public void MainStart()
        {
           
            //母港出征条件

            if (Compare1(992,218,231,130,49)&& Compare1(1004,218,231,130,49)&& Compare1(992, 218,231,130,49))
            {
                MuGangChuZheng();
           
            }

            ////母港出征点完了结果没选出击海域


          if (Compare1(307, 258, 107, 28, 24) && Compare1(465, 182, 107, 28, 24))
           // if (Compare1(294, 226, 107, 28, 24) && Compare1(449, 150, 107, 28, 24))

            {
                XuanZeHaiYu();
            }
            //if (Compare1(322,234,214,203,189) && Compare1(424,199,214,203,189))
            //{
            //    XuanZeHaiYu();
               
            //}

            //重新登录游戏后母港出征点完了结果没选出击海域

            if (Compare1(1193, 120, 189, 12, 8) && Compare1(327, 181, 189, 195, 181) && Compare1(279, 693, 0, 207, 0))
            {
                timerMain.Enabled = false;
                if (radioButton1.Checked == true)
                {

                    AlbatrossClick(766, 691);
                    Delay(5000);
                    AlbatrossClick(1320, 370);
                    Delay(5000);
                    AlbatrossClick(1320, 370);
                    Delay(5000);
                    AlbatrossClick(1320, 370);
                    Delay(5000);
                    AlbatrossClick(1320, 370);
                    Delay(5000);

                }
                if (radioButton2.Checked == true)
                {

                    AlbatrossClick(213, 366);
                    Delay(5000);
                    AlbatrossClick(213, 366);
                    Delay(5000);
                    AlbatrossClick(213, 366);
                    Delay(5000);

                }
                timerMain.Enabled = true;
            }
                //选择远征
                if (Compare1(273,727,140,165,82) && Compare1(1279,736,123,157,74))
            {
                ShouFaYuanZheng();
             }

            ////出征准备-出征开始
            if (Compare1(1253, 89, 132, 85, 16) && Compare1(1259, 604, 198, 135, 33))
            {
                ScanHP();
                Delay(1000);
                Supply();
                Delay(1000);
                ChuZhengKaiShi();
                
            }

            //出门啦 索敌成功 开始战斗按钮
            if (Compare1(851,682,173,73,8) && Compare1(1006,641,239,138,66))
            {
                ZhanDouKaiShi();
            }

            //选阵型
            if (Compare1(1075,142,74,204,82) && Compare1(1191,410,99,211,115)&& Compare1(1064, 685, 74, 199, 84))
            {
                XuanZhenXing();
            }

            //夜战突入吗
            if (Compare1(517,462,173,73,0) && Compare1(639, 461, 173, 73, 0))
            {
                YeZhanTuRu();
            }

            //战术评价
            if (Compare1(1130,542,255,255,255) || Compare1(1200, 600, 255, 255, 255))
            {
                ZhanShuPingJia();
            }
          
            //MVP评价
            if (Compare1(1148,684,66,207,247) && Compare1(1254,685,66,207,247))
            {
                MVPPingJia();
            }

            //获得新船
            //if (Compare1(1293,546,158,225,239) && Compare1(1311,557,182,178,222) && Compare1(1312,568,82,183,222))
            if (Compare1(115,697,206,203,206) && Compare1(85,688,99,97,99))
            {
                HuoDeXinChuan();
            }

            //旗舰大破啦
            if (Compare1(919,578,66,203,239) && Compare1(1108, 579, 66, 203, 239) && Compare1(783,242,8,121,189))
            {
                FanHuiMuGang();
            }

            //进击还是回港
            if (Compare1(737,350,66,207,239) && Compare1(866,397,0,146,198))
            {
                FanHuiMuGang();
            }

            //游戏没啦!
            if (Compare1(370, 403, 20, 23, 24) && Compare1(985, 402, 19, 22, 24) && Compare1(101,139,9,9,9) && Compare1(1287,145,9,9,9) && Compare1(70,739,35,39,43) && Compare1(682,407,21,24,24))
            {
                GameRestart();
            }

            //登录界面
            if (Compare1(1310,701,239,138,66) && Compare1(1203,748,173,73,8))
            {


                timerMain.Enabled = false;
                AlbatrossClick(679, 695);
                Delay(5000);
                AlbatrossClick(1301, 76);
                Delay(5000);
                AlbatrossClick(1093, 105);
               
                timerMain.Enabled = true;
            }

        }


        public bool Compare1(int d,int e,int a,int b,int c)
        {
           // GetColor(d, e);
         //   Sample(a,b,c);
            if
            (Compare2((int)GetColor(d,e).R, a) &&
            Compare2((int)GetColor(d, e).G, b) &&
            Compare2((int)GetColor(d, e).B, c))
            {
                return true;
            }
            else return false;
        }
        public bool Compare2(int f,int g)
        {
            int z= System.Math.Abs(f - g);
           
            if (z<50)
            {
                textBoxTest.Text = "true";
                //textBoxTest2.Text = Albatross.R.ToString()+" " + Albatross.G.ToString() + " " + Albatross.B.ToString();
                //textBoxTest3.Text = Albatross.SampleR.ToString() + " " + Albatross.SampleG.ToString() + " " + Albatross.SampleB.ToString();
                return true;
                    }
            textBoxTest.Text = "false";
           
            return false;
        }

     


        //public void Sample(int a,int b,int c)
        //{

        //    Albatross.SampleR = a;
        //    Albatross.SampleG = b;
        //    Albatross.SampleB = c;


        //}




    }

    //public class Albatross
    //    {


    //        public static int albatross;
        
      
    //    //public static int SampleR;
    //    //public static int SampleG;
    //    //public static int SampleB;
    //    // public static bool b=false;
    //}

  
    

    }

