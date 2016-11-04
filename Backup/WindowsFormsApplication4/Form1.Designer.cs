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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxTest = new System.Windows.Forms.TextBox();
            this.textBoxHPRedStart = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxAlbatross = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.buttonSaveXY = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.panel1.Controls.Add(this.buttonSaveXY);
            this.panel1.Controls.Add(this.textBoxY);
            this.panel1.Controls.Add(this.textBoxX);
            this.panel1.Controls.Add(this.buttonTest);
            this.panel1.Controls.Add(this.textBoxAlbatross);
            this.panel1.Controls.Add(this.textBoxColor);
            this.panel1.Location = new System.Drawing.Point(-1, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 143);
            this.panel1.TabIndex = 5;
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
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(143, 33);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 21);
            this.textBoxX.TabIndex = 6;
            this.textBoxX.Text = "textBoxX";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(143, 60);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 21);
            this.textBoxY.TabIndex = 7;
            this.textBoxY.Text = "textBoxY";
            // 
            // buttonSaveXY
            // 
            this.buttonSaveXY.Location = new System.Drawing.Point(143, 4);
            this.buttonSaveXY.Name = "buttonSaveXY";
            this.buttonSaveXY.Size = new System.Drawing.Size(100, 23);
            this.buttonSaveXY.TabIndex = 8;
            this.buttonSaveXY.Text = "buttonSaveXY";
            this.buttonSaveXY.UseVisualStyleBackColor = true;
            this.buttonSaveXY.Click += new System.EventHandler(this.buttonSaveXY_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxHPRedStart);
            this.Controls.Add(this.textBoxTest);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxTest;
        private System.Windows.Forms.TextBox textBoxHPRedStart;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxAlbatross;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonSaveXY;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
    }
}

