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
        private readonly int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        private readonly int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        private readonly int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        private readonly int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 

        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private void button1_Click(object sender, EventArgs e)
        {
            PracticeStart();
        }

        // 测试用代码
        private void buttonTest_Click(object sender, EventArgs e)
        {
           // textBoxTest.Text = ColorToString(GetColor(x, y));
            AlbatrossClick(533, 368);
        }

        private void buttonSaveXY_Click(object sender, EventArgs e)
        {
            x = Int32.Parse(textBoxX.Text);
            y = Int32.Parse(textBoxY.Text);
        }

        //测试用代码结束

        //需要一个验证断网的验证函数

        //还需要一个验证操作成功的验证函数

        //鼠标点击模拟函数
        private int AlbatrossClick(int x,int y)
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
            string i = "";
            Albatross.RedBloodShipNumber = 7;
            i = ColorToString(GetColor(359, 445));//第一艘船
            if (Albatross.albatross < 526530 && Albatross.albatross > 526520)//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                Albatross.RedBloodShipNumber = 1;
            }
            else
            {
                textBoxTest.Text = "安全安全...大概!";
            }

            i = ColorToString(GetColor(493, 445));//第二艘船
            if (Albatross.albatross < 526530 && Albatross.albatross > 526520)//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                Albatross.RedBloodShipNumber = 2;
            }
            else
            {
                textBoxTest.Text = "安全安全...大概!";
            }

            i = ColorToString(GetColor(625, 445));//第三艘船
            if (Albatross.albatross < 526530 && Albatross.albatross > 526520)//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                Albatross.RedBloodShipNumber = 3;
            }
            else
            {
                textBoxTest.Text = "安全安全...大概!";
            }

            i = ColorToString(GetColor(757, 445));//第四艘船
            if (Albatross.albatross < 526530 && Albatross.albatross > 526520)//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                Albatross.RedBloodShipNumber = 4;
            }
            else
            {
                textBoxTest.Text = "安全安全...大概!";
            }

            i = ColorToString(GetColor(891, 445));//第五艘船
            if (Albatross.albatross < 526530 && Albatross.albatross > 526520)//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                Albatross.RedBloodShipNumber = 5;
            }
            else
            {
                textBoxTest.Text = "安全安全...大概!";
            }

            i = ColorToString(GetColor(1023, 445));//第六艘船
            if (Albatross.albatross < 526530 && Albatross.albatross > 526520)//母港红血条件
            {
                textBoxTest.Text = "大破警告!";
                Albatross.RedBloodShipNumber = 6;
            }
            else
            {
                textBoxTest.Text = "安全安全...大概!";
            }


            if (Albatross.RedBloodShipNumber == 7)
            {
                return;
            }
            else
            {
                FixBoat();
                textBoxHPRedStart.Text = Albatross.RedBloodShipNumber.ToString();
                ScanHP();
            }

        }

        private void FixBoat()
        {
            //x = 1260;
            //y = 220;
            AlbatrossClick(1260, 220);
            Delay(1000);

            if (Albatross.RedBloodShipNumber == 1)
            {
            //    x = 282;
            //    y = 335;
                AlbatrossClick(282, 335); 
                Delay(1000);

                x = 1032;
                y = 172;
                mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
                Delay(1000);
            }
            else
            {
                if (Albatross.RedBloodShipNumber == 2)
                {
                    x = 414;
                    y = 335;
                    mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                    mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起

                    Delay(1000);

                    x = 1032;
                    y = 172;
                    mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                    mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
                    Delay(1000);
                }
                else
                {
                    if (Albatross.RedBloodShipNumber == 3)
                    {
                        x = 545;
                        y = 335;
                        mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                        mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起

                        Delay(1000);

                        x = 1032;
                        y = 172;
                        mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                        mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
                        Delay(1000);
                    }
                    else
                    {
                        if (Albatross.RedBloodShipNumber == 4)
                        {
                            x = 680;
                            y = 335;
                            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起

                            Delay(1000);

                            x = 1032;
                            y = 172;
                            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
                            Delay(1000);
                        }
                        else
                        {
                            if (Albatross.RedBloodShipNumber == 5)
                            {
                                x = 808;
                                y = 335;
                                mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                                mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起

                                Delay(1000);

                                x = 1032;
                                y = 172;
                                mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                                mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
                                Delay(1000);
                            }
                            else
                            {
                                if (Albatross.RedBloodShipNumber == 6)
                                {
                                    x = 940;
                                    y = 335;
                                    mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                                    mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起

                                    Delay(1000);

                                    x = 1032;
                                    y = 172;
                                    mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
                                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
                                    mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
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
           x=1258;
            y=112;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(1000);

            x = 893;
            y = 573;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(5000);

            return;
        }

        public void PracticeStart()
        {
            Supply();
            Delay(5000);
            ScanHP();
            Delay(5000);
            
            //出征开始
            x = 672;
            y = 713;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(20000);

            //战斗开始,之前的罗盘+索敌全部等待20秒跳过
            x = 929;
            y = 659;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(5000);

            //选阵型 当然是复纵阵啦
            x = 1171;
            y = 275;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(120000);

            //夜战突入吗?选否
            x = 802;
            y = 371;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(10000);
            //战术评价 点击继续 再点一下
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(10000);

            //MVP评价 继续按钮
            x = 1206;
            y = 711;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(10000);

            //回港 或 返回母港 先点一下返回母港 1006 600 1008 622
            x = 801;
            y = 375;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(10000);

            //再出征
            x = 1007;
            y = 273;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//点击
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(10000);
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / 1366, y * 65535 / 768, 0, 0);//抬起
            Delay(10000);



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

        

      

    


    }  
    public class Albatross
        {


            public static int albatross;
            public static int RedBloodShipNumber;

            // public static bool b=false;
        }



    }

