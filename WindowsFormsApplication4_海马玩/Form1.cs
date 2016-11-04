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


namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        int x;
        int y;
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x0002;//模拟鼠标移动
        private readonly int MOUSEEVENTF_MOVE = 0x0001;//模拟鼠标左键按下
        private readonly int MOUSEEVENTF_LEFTUP = 0x0004;//模拟鼠标左键抬起
        private readonly int MOUSEEVENTF_ABSOLUTE = 0x8000;//鼠标绝对位置
        //private readonly int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        //private readonly int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        //private readonly int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        //private readonly int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 
        public bool Exit = false;

        NotifyIcon notifyicon = new NotifyIcon();
        //创建托盘图标对象 
        Icon ico = new Icon("snow.ico");
        //创建托盘菜单对象 
        ContextMenu notifyContextMenu = new ContextMenu();

        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        // 测试用代码
        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (Compare1(66, 193, 197, 183, 160) && Compare1(1170, 35, 255, 255, 255) && Compare1(260, 91, 6, 110, 176))
            {
                textBoxTest.Text = "true";

            }
            else
            {
                textBoxTest.Text = "false"; 
            }
        }


        //鼠标点击模拟函数
        private int AlbatrossClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            return 0;
        }


        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32")]
        public static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        public Color GetColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero); uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF), (int)(pixel & 0x0000FF00) >> 8, (int)(pixel & 0x00FF0000) >> 16);
            textBoxColor.Text = color.ToString();
            Albatross.albatross = (int)pixel;
            textBoxAlbatross.Text = Albatross.albatross.ToString();
            Albatross.R = (int)color.R;
            Albatross.G = (int)color.G;
            Albatross.B = (int)color.B;
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
            // if (Compare1(359,445, 186, 8, 8))//母港红血条件
            if (Compare1(341, 428, 186, 8, 8))
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(1);
            }

            //第二艘船
            //if (Compare1(493, 445, 186, 8, 8))//母港红血条件
            if (Compare1(481, 428, 186, 8, 8))
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(2);
            }


            //第三艘船
            //if (Compare1(625, 445, 186, 8, 8))//母港红血条件
            if (Compare1(621, 428, 186, 8, 8))
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(3);
            }


            //第四艘船
            //if (Compare1(757, 445, 186, 8, 8))//母港红血条件
            if (Compare1(761, 428, 186, 8, 8))
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(4);
            }


            //第五艘船
            //if (Compare1(891, 445, 186, 8, 8))//母港红血条件
            if (Compare1(901, 428, 186, 8, 8))
            {
                textBoxTest.Text = "大破警告!";
                ScanExit = 0;
                FixBoat(5);
            }


            //第六艘船
            //if (Compare1(1024,445,186,8,8))//母港红血条件
            if (Compare1(1041, 428, 186, 8, 8))
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
            //淦...原来的位置不记得了
            AlbatrossClick(1288, 188);
            Delay(1000);

            if (l == 1)
            {
                //    x = 282;
                //    y = 335;
                //    AlbatrossClick(282, 335); 
                AlbatrossClick(258, 338);
                Delay(1000);

                // AlbatrossClick(1032, 172);
                AlbatrossClick(1050, 141);
                Delay(1000);
            }
            else
            {
                if (l == 2)
                {
                    //AlbatrossClick(414, 335);
                    AlbatrossClick(396, 335);
                    Delay(1000);
                    AlbatrossClick(1050, 141);
                    Delay(1000);
                }
                else
                {
                    if (l == 3)
                    {
                        AlbatrossClick(545, 335);
                        Delay(1000);
                        AlbatrossClick(1050, 141);
                        Delay(1000);
                    }
                    else
                    {
                        if (l == 4)
                        {
                            AlbatrossClick(680, 335);
                            Delay(1000);
                            AlbatrossClick(1050, 141);
                            Delay(1000);
                        }
                        else
                        {
                            if (l == 5)
                            {
                                AlbatrossClick(808, 335);
                                Delay(1000);
                                AlbatrossClick(1050, 141);
                                Delay(1000);
                            }
                            else
                            {
                                if (l == 6)
                                {
                                    AlbatrossClick(940, 335);
                                    Delay(1000);
                                    AlbatrossClick(1050, 141);
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
            //x = 1258;
            //y = 112;
            x = 1290;
            y = 80;

            AlbatrossClick(x, y);
            Delay(1000);

            // x = 893;
            // y = 573;
            x = 908;
            y = 561;

            AlbatrossClick(x, y);
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
            x = 672;
            y = 713;

            AlbatrossClick(x, y);
        }

        private void ZhanDouKaiShi()
        {
            //索敌成功 开始战斗
            // x = 929;
            // y = 659;
            x = 944;
            y = 658;
            AlbatrossClick(x, y);
        }

        //选择海域
        private void XuanZeHaiYu()
        {


            if (Compare1(1235, 86, 187, 10, 10) && Compare1(921, 87, 232, 61, 61) && Compare1(297, 142, 189, 197, 186))
            {
                timerMain.Enabled = false;
                if (radioButton1.Checked == true)
                {

                    AlbatrossClick(803, 701);
                    Delay(5000);
                    AlbatrossClick(1351, 346);
                    Delay(5000);
                    AlbatrossClick(1351, 346);
                    Delay(5000);
                    AlbatrossClick(1351, 346);
                    Delay(5000);
                    AlbatrossClick(1351, 346);
                    Delay(5000);

                }
                if (radioButton2.Checked == true)
                {

                    AlbatrossClick(182, 347);
                    Delay(5000);
                    AlbatrossClick(182, 347);
                    Delay(5000);
                    AlbatrossClick(182, 347);
                    Delay(5000);

                }
                timerMain.Enabled = true;
            }
            else
            {
                x = 766;
                y = 420;
                AlbatrossClick(x, y);

            }



        }


        private void XuanZhenXing()
        {
            //选阵型啦
            if (radioButton1.Checked == true)
            {
                //x = 1171;
                //y = 275;
                x = 1200;
                y = 250;

                AlbatrossClick(x, y);
            }
            if (radioButton2.Checked == true)
            {
                //x = 1086;
                //y = 671;
                x = 1111;
                y = 666;
                AlbatrossClick(x, y);
            }
            else
            {
                x = 1200;
                y = 250;

                AlbatrossClick(x, y);
            }
        }

        private void YeZhanTuRu()
        {
            //夜战突入吗
            x = 810;
            y = 350;
            AlbatrossClick(x, y);
            Delay(10000);
            AlbatrossClick(x, y);
        }

        private void ZhanShuPingJia()
        {
            //战术评价
            x = 802;
            y = 371;
            AlbatrossClick(x, y);
        }

        private void MVPPingJia()
        {
            //MVP评价
            //x = 1206;
            //y = 711;
            x = 1234;
            y = 710;

            AlbatrossClick(x, y);
        }


        private void HuoDeXinChuan()
        {
            //获得新船
            x = 1206;
            y = 711;
            AlbatrossClick(x, y);
        }

        private void FanHuiMuGang()
        {
            //反回母港
            x = 1029;
            y = 590;
            AlbatrossClick(x, y);
            Delay(1000);
            x = 805;
            y = 356;
            AlbatrossClick(x, y);
        }

        private void MuGangChuZheng()
        {

            x = 1025;
            y = 244;
            AlbatrossClick(x, y);
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
                    AlbatrossClick(101, 676);
                    break;
                default:
                    Delay(5000);
                    AlbatrossClick(101, 676);
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
            if (Compare1(1282, 110, 173, 74, 4))
            {
                return "1";
            }
            //红色条件2
            if (Compare1(1272, 272, 173, 74, 4))
            {
                return "2";
            }
            //红色条件3
            if (Compare1(1282, 431, 173, 74, 4))
            {
                return "3";
            }
            //红色条件4
            if (Compare1(1282, 592, 173, 74, 4))
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
                x = 1282;
                y = 110;

                YuanZhengCaoZuo(x, y);
            }
            if (h == 2)
            {
                x = 1272;
                y = 272;
                YuanZhengCaoZuo(x, y);
            }
            if (h == 3)
            {
                x = 1282;
                y = 431;
                YuanZhengCaoZuo(x, y);
            }
            if (h == 4)
            {
                x = 1282;
                y = 592;
                YuanZhengCaoZuo(x, y);
            }
        }

        //远征-逻辑....逻辑你大爷啊用得着这么多吗?
        public void YuanZhengCaoZuo(int x, int y)
        {
            Delay(5000);
            AlbatrossClick(x, y);
            Delay(5000);
            AlbatrossClick(x, y);
            Delay(5000);
            AlbatrossClick(x, y);
            Delay(5000);
            //2
            x = 640;
            y = 518;
            AlbatrossClick(x, y);
            Delay(2000);
            //出征
            x = 670;
            y = 710;
            AlbatrossClick(x, y);
            Delay(2000);

            //3
            x = 777;
            y = 514;
            AlbatrossClick(x, y);
            Delay(2000);
            //出征
            x = 670;
            y = 710;
            AlbatrossClick(x, y);
            Delay(2000);

            //4
            x = 913;
            y = 516;
            AlbatrossClick(x, y);
            Delay(1000);
            //出征
            x = 670;
            y = 710;
            AlbatrossClick(x, y);

            Delay(5000);
            AlbatrossClick(101, 676);
        }

        private void GameRestart()
        {

            AlbatrossClick(506, 314);

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
            timerMain.Enabled = true;
          //  this.WindowState = FormWindowState.Minimized;
        }

        private void buttonMainExit_Click(object sender, EventArgs e)
        {
            timerMain.Enabled = false;

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //判断是否已经最小化于托盘 
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                notifyicon.Visible = false;
            }
        }

        //大概是
        private void timerMain_Tick(object sender, EventArgs e)
        {
            MainStart();
        }

        public void MainStart()
        {

            //母港出征条件

            if (Compare1(1334, 34, 255, 255, 255) && Compare1(1009, 200, 225, 124, 44) && Compare1(23, 710, 230, 129, 51))
            {
                MuGangChuZheng();

            }

            ////母港出征点完了结果没选出击海域


            // if (Compare1(307, 258, 107, 28, 24) && Compare1(465, 182, 107, 28, 24))
            if (Compare1(70, 53, 238, 137, 64) && Compare1(256, 691, 0, 205, 0))

            {
                XuanZeHaiYu();
            }
            //if (Compare1(322,234,214,203,189) && Compare1(424,199,214,203,189))
            //{
            //    XuanZeHaiYu();

            //}

            //重新登录游戏后母港出征点完了结果没选出击海域
            //已经移走了

            //选择远征
            if (Compare1(72, 53, 68, 207, 243) && Compare1(71, 255, 237, 136, 61) && Compare1(255, 690, 0, 205, 0))
            {
                ShouFaYuanZheng();
            }

            ////出征准备-出征开始
            if (Compare1(66, 193, 197, 183, 160) && Compare1(1170, 35, 255, 255, 255) && Compare1(260, 91, 6, 110, 176))
            {
                ScanHP();
                Delay(1000);
                Supply();
                Delay(1000);
                ChuZhengKaiShi();

            }

            //出门啦 索敌成功 开始战斗按钮
            if (Compare1(851, 682, 173, 73, 8) && Compare1(1006, 641, 239, 138, 66))
            {
                ZhanDouKaiShi();
            }

            //选阵型
            if (Compare1(1075, 142, 74, 204, 82) && Compare1(1191, 410, 99, 211, 115) && Compare1(1064, 685, 74, 199, 84))
            {
                XuanZhenXing();
            }

            //夜战突入吗
            if (Compare1(466, 396, 231, 130, 53) && Compare1(623, 443, 178, 75, 2) && Compare1(737, 326, 67, 203, 240) && Compare1(881, 371, 0, 145, 194))
            {
                YeZhanTuRu();
            }

            //战术评价
            if (Compare1(1160, 522, 255, 255, 255) || Compare1(1200, 600, 255, 255, 255))
            {
                ZhanShuPingJia();
            }
            textBoxTest.Text = Albatross.RedBloodShipNumber.ToString();
            //MVP评价
            // if (Compare1(1148,684,66,207,247) && Compare1(1254,685,66,207,247))
            if (Compare1(1199, 707, 255, 255, 255) && Compare1(1274, 715, 255, 255, 255))
            {
                MVPPingJia();
            }

            //获得新船
            //if (Compare1(1293,546,158,225,239) && Compare1(1311,557,182,178,222) && Compare1(1312,568,82,183,222))
            if (Compare1(65, 729, 102, 102, 102) && Compare1(82, 698, 204, 204, 204))
            {
                HuoDeXinChuan();
            }

            //旗舰大破啦
            if (Compare1(919, 578, 66, 203, 239) && Compare1(1108, 579, 66, 203, 239) && Compare1(783, 242, 8, 121, 189))
            {
                FanHuiMuGang();
            }

            //进击还是回港
            if (Compare1(735, 328, 67, 204, 241) && Compare1(476, 394, 232, 131, 54) && Compare1(829, 356, 252, 253, 255))
            {
                FanHuiMuGang();
            }

            //游戏没啦!
            if (Compare1(463, 263, 255, 255, 255) && Compare1(548, 266, 255, 255, 255) && Compare1(462, 347, 255, 255, 255) && Compare1(548, 348, 255, 255, 255) && Compare1(1245, 674, 255, 255, 255))
            {
                GameRestart();
            }

            //登录界面
            if (Compare1(1332, 698, 239, 138, 64) && Compare1(1232, 747, 172, 74, 5) && Compare1(1267, 703, 255, 248, 238))
            {


                timerMain.Enabled = false;
                AlbatrossClick(686, 686);
                Delay(5000);
                AlbatrossClick(1335, 41);
                Delay(5000);
                AlbatrossClick(1118, 72);

                timerMain.Enabled = true;
            }

        }


        public bool Compare1(int d, int e, int a, int b, int c)
        {
            GetColor(d, e);
            Sample(a, b, c);
            if
            (Compare2(Albatross.R, Albatross.SampleR) &&
            Compare2(Albatross.G, Albatross.SampleG) &&
            Compare2(Albatross.B, Albatross.SampleB))
            {
                return true;
            }
            else return false;
        }
        public bool Compare2(int f, int g)
        {
            int z = System.Math.Abs(f - g);
            Albatross.RedBloodShipNumber = z;
            if (z < 50)
            {
                textBoxTest.Text = "true";
                return true;
            }
            textBoxTest.Text = "false";

            return false;
        }
        public void Sample(int a, int b, int c)
        {

            Albatross.SampleR = a;
            Albatross.SampleG = b;
            Albatross.SampleB = c;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.Text = "笑话";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //判断是否已经最小化于托盘 
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                notifyicon.Visible = false;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮 
            if (WindowState == FormWindowState.Minimized)
            {
                //托盘显示图标等于托盘图标对象 
                //注意notifyIcon1是控件的名字而不是对象的名字 
                notifyIcon1.Icon = ico;
                //隐藏任务栏区图标 
                this.ShowInTaskbar = false;
                //图标显示在托盘区 
                notifyicon.Visible = true;
            }
        }

        public class Albatross
        {


            public static int albatross;
            public static int RedBloodShipNumber;
            public static int R;
            public static int G;
            public static int B;
            public static int SampleR;
            public static int SampleG;
            public static int SampleB;
            // public static bool b=false;
        }




    }
}

