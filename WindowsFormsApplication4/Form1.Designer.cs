namespace WindowsFormsApplication4
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxTest = new System.Windows.Forms.TextBox();
            this.textBoxHPRedStart = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxAlbatross = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonMainStart = new System.Windows.Forms.Button();
            this.buttonMainExit = new System.Windows.Forms.Button();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.textBoxTest2 = new System.Windows.Forms.TextBox();
            this.textBoxTest3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.FlipButton = new System.Windows.Forms.Button();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTest
            // 
            this.textBoxTest.Location = new System.Drawing.Point(142, 14);
            this.textBoxTest.Name = "textBoxTest";
            this.textBoxTest.Size = new System.Drawing.Size(100, 21);
            this.textBoxTest.TabIndex = 1;
            this.textBoxTest.Text = "textBoxTest";
            // 
            // textBoxHPRedStart
            // 
            this.textBoxHPRedStart.Location = new System.Drawing.Point(142, 57);
            this.textBoxHPRedStart.Name = "textBoxHPRedStart";
            this.textBoxHPRedStart.Size = new System.Drawing.Size(100, 21);
            this.textBoxHPRedStart.TabIndex = 2;
            this.textBoxHPRedStart.Text = "textBoxHPRedStart";
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(13, 108);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(100, 21);
            this.textBoxColor.TabIndex = 3;
            this.textBoxColor.Text = "textBoxColor";
            // 
            // textBoxAlbatross
            // 
            this.textBoxAlbatross.Location = new System.Drawing.Point(143, 108);
            this.textBoxAlbatross.Name = "textBoxAlbatross";
            this.textBoxAlbatross.Size = new System.Drawing.Size(100, 21);
            this.textBoxAlbatross.TabIndex = 4;
            this.textBoxAlbatross.Text = " textBoxAlbatross";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.buttonTest);
            this.panel1.Controls.Add(this.textBoxAlbatross);
            this.panel1.Controls.Add(this.textBoxColor);
            this.panel1.Location = new System.Drawing.Point(-1, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 143);
            this.panel1.TabIndex = 5;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(148, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "单横阵";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(148, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "复纵阵";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(13, 71);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 5;
            this.buttonTest.Text = "buttonTest";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonMainStart
            // 
            this.buttonMainStart.Location = new System.Drawing.Point(325, 14);
            this.buttonMainStart.Name = "buttonMainStart";
            this.buttonMainStart.Size = new System.Drawing.Size(75, 23);
            this.buttonMainStart.TabIndex = 6;
            this.buttonMainStart.Text = "肝船开始!";
            this.buttonMainStart.UseVisualStyleBackColor = true;
            this.buttonMainStart.Click += new System.EventHandler(this.buttonMainStart_Click);
            // 
            // buttonMainExit
            // 
            this.buttonMainExit.Location = new System.Drawing.Point(325, 57);
            this.buttonMainExit.Name = "buttonMainExit";
            this.buttonMainExit.Size = new System.Drawing.Size(75, 23);
            this.buttonMainExit.TabIndex = 7;
            this.buttonMainExit.Text = "退出肝船!";
            this.buttonMainExit.UseVisualStyleBackColor = true;
            this.buttonMainExit.Click += new System.EventHandler(this.buttonMainExit_Click);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 10000;
            this.timerMain.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxTest2
            // 
            this.textBoxTest2.Location = new System.Drawing.Point(23, 12);
            this.textBoxTest2.Name = "textBoxTest2";
            this.textBoxTest2.Size = new System.Drawing.Size(100, 21);
            this.textBoxTest2.TabIndex = 8;
            this.textBoxTest2.Text = "textBoxTest2";
            // 
            // textBoxTest3
            // 
            this.textBoxTest3.Location = new System.Drawing.Point(23, 57);
            this.textBoxTest3.Name = "textBoxTest3";
            this.textBoxTest3.Size = new System.Drawing.Size(100, 21);
            this.textBoxTest3.TabIndex = 9;
            this.textBoxTest3.Text = "textBoxTest3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(406, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(366, 337);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // FlipButton
            // 
            this.FlipButton.Location = new System.Drawing.Point(313, 141);
            this.FlipButton.Name = "FlipButton";
            this.FlipButton.Size = new System.Drawing.Size(75, 23);
            this.FlipButton.TabIndex = 11;
            this.FlipButton.Text = "FlipButton";
            this.FlipButton.UseVisualStyleBackColor = true;
            this.FlipButton.Click += new System.EventHandler(this.FlipButton_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(792, 12);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(380, 337);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 361);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.FlipButton);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxTest3);
            this.Controls.Add(this.textBoxTest2);
            this.Controls.Add(this.buttonMainExit);
            this.Controls.Add(this.buttonMainStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxHPRedStart);
            this.Controls.Add(this.textBoxTest);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "waht";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxTest;
        private System.Windows.Forms.TextBox textBoxHPRedStart;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxAlbatross;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonMainStart;
        private System.Windows.Forms.Button buttonMainExit;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TextBox textBoxTest2;
        private System.Windows.Forms.TextBox textBoxTest3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button FlipButton;
        private Emgu.CV.UI.ImageBox imageBox2;
    }
}

